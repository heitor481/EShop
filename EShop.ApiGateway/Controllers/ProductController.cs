using EShop.Infra.Commnad.Product;
using EShop.Infra.EShopConts;
using EShop.Infra.Events.Product;
using EShop.Infra.Queries.Product;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IRequestClient<GetProductById> _requestClient;

        public ProductController(IBusControl busControl, IRequestClient<GetProductById> requestClient)
        {
            _busControl = busControl;
            _requestClient = requestClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var productId = new GetProductById() { Id = id };
            var product = await _requestClient.GetResponse<ProductCreated>(productId);

            if (product.Message == null) 
            {
                throw new Exception("Product not found");
            }

            return Accepted(product.Message);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(CreateProduct input) 
        {
            var url = new Uri(EShopConst.RabbitMQConnection + "/create_product");
            var endpoint = await _busControl.GetSendEndpoint(url);
            await endpoint.Send(input);
            return Accepted("Product Created");
        }
    }
}
