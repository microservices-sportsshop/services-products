using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.ApplicationCore.Interfaces;
using Sports.Data.Entities;
using Sports.Persistence;

namespace Sports.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SportsShopDbContext _sportsShopDbContext;
        private readonly IProductsBusiness _productsBusiness;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(SportsShopDbContext sportsShopDbContext, IProductsBusiness productsBusiness, ILogger<ProductsController> logger)
        {
            _sportsShopDbContext = sportsShopDbContext ?? throw new ArgumentNullException(nameof(sportsShopDbContext));

            _productsBusiness = productsBusiness ?? throw new ArgumentNullException(nameof(productsBusiness));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsController::GetProducts()");

            return Ok(await _productsBusiness.GetProducts());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsController::GetProductById()");

            return await _sportsShopDbContext.Products.FindAsync(id) is Product course ? Ok(course) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            _logger.LogInformation($"Starting ProductsController::AddProduct()");

            _sportsShopDbContext.Products.Add(product);
            await _sportsShopDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ModifyProductById(Guid id, Product product)
        {
            _logger.LogInformation($"Starting ProductsController::ModifyProductById()");

            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!await _sportsShopDbContext.Products.AnyAsync(p => p.Id == id))
            {
                return NotFound();
            }

            _sportsShopDbContext.Entry(product).State = EntityState.Modified;

            try
            {
                await _sportsShopDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsController::DeleteProductById()");

            var product = await _sportsShopDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _sportsShopDbContext.Products.Remove(product);
            await _sportsShopDbContext.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPost]
        [Route("deleteproducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProducts([FromQuery] Guid[] ids)
        {
            _logger.LogInformation($"Starting ProductsController::DeleteProducts()");

            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _sportsShopDbContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }

            _sportsShopDbContext.Products.RemoveRange(products);
            await _sportsShopDbContext.SaveChangesAsync();

            return Ok(products);
        }

    }

}
