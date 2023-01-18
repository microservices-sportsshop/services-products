using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.Data.Entities;
using Sports.Persistence;

namespace Sports.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SportsShopDbContext _context;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(SportsShopDbContext context, ILogger<ProductsController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsController::GetProducts()");

            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            _logger.LogInformation($"Starting ProductsController::GetProductById()");

            return await _context.Products.FindAsync(id) is Product course ? Ok(course) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ModifyProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!await _context.Products.AnyAsync(p => p.Id == id))
            {
                return NotFound();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpPost]
        [Route("deleteproducts")]
        public async Task<ActionResult> DeleteProducts([FromQuery] Guid[] ids)
        {
            var products = new List<Product>();
            foreach (var id in ids)
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound();
                }

                products.Add(product);
            }

            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();

            return Ok(products);
        }

    }

}
