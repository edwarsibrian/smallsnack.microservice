using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Queries;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class GetProductAvailableHandler : IRequestHandler<GetProductsAvailableQuery, List<Product>>
    {
        private readonly IProductService _productService;

        public GetProductAvailableHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<Product>> Handle(GetProductsAvailableQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductsAvailable();
        }
    }
}