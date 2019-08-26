using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Description = request.Description,
                Amount = request.Amount,
                Price = request.Price
            };

            return await _productService.AddProduct(product);
        }
    }
}