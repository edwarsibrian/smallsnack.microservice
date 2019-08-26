using System.Collections.Generic;
using MediatR;
using SmallSnack.Microservice.Domain.Entities;

namespace SmallSnack.Microservice.Domain.Queries
{
    public class GetProductsAvailableQuery : IRequest<List<Product>>
    {
        
    }
}