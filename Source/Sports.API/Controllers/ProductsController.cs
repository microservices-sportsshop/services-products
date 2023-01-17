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
        public async Task<IEnumerable<Product>> GetProducts()
        {
            _logger.LogInformation($"Starting ProductsController::GetProducts()");

            return await _context.Products.ToListAsync();
        }

    }

}
