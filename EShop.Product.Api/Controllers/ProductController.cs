using EShop.Infra.Commnad.Product;
using EShop.Product.DataProvider.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.Product.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		
		public async Task<ActionResult> Get(string id) 
		{
			var product = await _productService.GetProduct(id);
			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateProduct input) 
		{
			var addProduct = await _productService.AddProduct(input);
			return Ok(addProduct);
		}
	}
}
