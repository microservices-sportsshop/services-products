using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            return (product is null) ? NotFound() : Ok(product);
        }

    }

}
