﻿using EShop.Infra.Commnad.Product;
using EShop.Infra.Events.Product;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Product.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<CreateProduct> _mongoCollection;

        public ProductRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
            _mongoCollection = _mongoDatabase.GetCollection<CreateProduct>("Product");
            
        }

        public async Task<ProductCreated> Add(CreateProduct input)
        {
            await _mongoCollection.InsertOneAsync(input);
            return new ProductCreated();
        }

        public async Task<ProductCreated> Get(Guid id)
        {
            var product =  _mongoCollection.AsQueryable().Where(x => x.Id == id).FirstOrDefault();

            if (product == null) 
            {
                throw new Exception("Product not found");
            }
            await Task.CompletedTask;
            return new ProductCreated();
        }
    }
}