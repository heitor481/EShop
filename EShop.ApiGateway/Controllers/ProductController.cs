using EShop.Infra.Commnad.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.CompletedTask;
            return Accepted("Get product");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProduct input) 
        {
            await Task.CompletedTask;
            return Accepted("Product Created");
        }
    }
}
