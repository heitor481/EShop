using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.DataProvider.Services
{
    public interface IProductService
    {
        Task<ProductCreated> GetProduct(string id);
        Task<ProductCreated> AddProduct(CreateProduct input);
    }
}
