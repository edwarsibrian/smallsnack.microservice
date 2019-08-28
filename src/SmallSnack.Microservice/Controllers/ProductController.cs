using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Queries;

namespace SmallSnack.Microservice.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<bool> Post(AddProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut]
        public async Task<bool> Put(UpdatePriceProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize(Roles = "Administrator")]
        [HttpDelete]
        public async Task<bool> Delete(DeleteProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("getproductsavailable")]
        public async Task<List<Product>> GetProductsAvailable(GetProductsAvailableQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}