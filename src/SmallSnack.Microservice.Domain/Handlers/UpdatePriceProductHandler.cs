using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class UpdatePriceProductHandler : IRequestHandler<UpdatePriceProductCommand, bool>
    {
        private readonly IProductService _productService;

        public UpdatePriceProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdatePriceProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.UpdatePrice(request.Id, request.Price);
        }
    }
}