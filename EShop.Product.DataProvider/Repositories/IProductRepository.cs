using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using System.Threading.Tasks;

namespace EShop.Product.DataProvider.Repositories
{
    public interface IProductRepository
    {
        Task<ProductCreated> Get(string id);
        Task<ProductCreated> Add(CreateProduct input);
    }
}
