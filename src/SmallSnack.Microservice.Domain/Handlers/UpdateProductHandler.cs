using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.UpdatedProduct(request.Id, request.Price);
        }
    }
}