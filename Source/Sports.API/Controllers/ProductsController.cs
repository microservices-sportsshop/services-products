using Microsoft.AspNetCore.Mvc;

namespace Sports.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public void GetProducts()
        {

        }

    }

}
