using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Repo;

namespace SmallSnack.Microservice.Domain.Services
{
    public interface IProductService
    {
        Task<bool> Add(Product product);
        Task<bool> UpdatePrice(int id, double price);
        Task<bool> AddAmount(int id, int amount);
        Task<List<Product>> GetProductsAvailable();
        Task<bool> Delete(int id);
        Task<bool> Buy(int productId, int amount, int userId);
        Task<bool> Like(int productId);
    }
    public class ProductService : IProductService
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Product product)
        {
            await _context.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatePrice(int id, double price)
        {
            var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);

            if (product == null)
            {
                throw new Exception("Product id invalid");
            }

            product.Price = price;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddAmount(int id, int amount)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);

            if(product==null)
                throw new Exception("Product id invalid");

            product.Amount = amount;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetProductsAvailable()
        {
            return await _context.Products.Where(s => s.Amount > 0).ToListAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var product = new Product {Id = id};

            _context.Remove(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Buy(int productId, int amount, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Like(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == productId);

            if (product == null)
                throw new Exception("Product Id invalid");

            product.Linking++;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}