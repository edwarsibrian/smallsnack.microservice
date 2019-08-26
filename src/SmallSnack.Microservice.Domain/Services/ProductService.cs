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
        Task<bool> AddProduct(Product product);
        Task<bool> UpdatedProduct(int id, double price);
        Task<List<Product>> GetProductsAvailable();
    }
    public class ProductService : IProductService
    {
        private DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await _context.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdatedProduct(int id, double price)
        {
            var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);

            if (product == null)
            {
                throw new Exception("Product id invalid");
            }

            product.Price = price;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetProductsAvailable()
        {
            return await _context.Products.Where(s => s.Amount > 0).ToListAsync();
        }
    }
}