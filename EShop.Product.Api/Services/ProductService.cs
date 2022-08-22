using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductCreated> AddProduct(CreateProduct input)
        {
            throw new NotImplementedException();
        }

        public Task<ProductCreated> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
