using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using EShop.Product.DataProvider.Repositories;
using System.Threading.Tasks;

namespace EShop.Product.DataProvider.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
            _productRepository = productRepository;
		}

        public Task<ProductCreated> AddProduct(CreateProduct input)
        {
            return _productRepository.Add(input);
        }

        public Task<ProductCreated> GetProduct(string id)
        {
            return _productRepository.Get(id);
        }
    }
}
