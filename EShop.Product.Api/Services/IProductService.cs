using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
{
    public interface IProductService
    {
        Task<ProductCreated> GetProduct(Guid id);
        Task<ProductCreated> AddProduct(CreateProduct input);
    }
}
