using EShop.Infra.Queries.Product;
using EShop.Product.DataProvider.Services;
using MassTransit;
using System.Threading.Tasks;

namespace EShop.Product.Query.Api.Handles
{
    public class GetProductByIdHandler : IConsumer<GetProductById>
    {
        private readonly IProductService _productService;

        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<GetProductById> context)
        {
            var product = await _productService.GetProduct(context.Message.Id);
            await context.RespondAsync(product);
        }
    }
}
