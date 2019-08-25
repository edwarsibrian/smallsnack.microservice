using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Responses;

namespace SmallSnack.Microservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<UserAuthenticatedResponse> Authenticate(UserAuthenticateCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}