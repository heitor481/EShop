using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using EShop.Product.Api.Repositories;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
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

        public Task<ProductCreated> GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }
    }
}
