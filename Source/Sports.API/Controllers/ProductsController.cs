using Microsoft.AspNetCore.Mvc;
using Sports.Persistence;

namespace Sports.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SportsShopDbContext _context;

        public ProductsController(SportsShopDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public void GetProducts()
        {
            var results = _context.Products.ToList();
        }

    }

}
