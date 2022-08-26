using EShop.Infra.Commnad.Product;
using EShop.Infra.EShopConts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EShop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBusControl _busControl;

        public ProductController(IBusControl busControl)
        {
            _busControl = busControl;
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
            var url = new Uri(EShopConst.RabbitMQConnection + "/create_product");
            var endpoint = await _busControl.GetSendEndpoint(url);
            await endpoint.Send(input);
            return Accepted("Product Created");
        }
    }
}
