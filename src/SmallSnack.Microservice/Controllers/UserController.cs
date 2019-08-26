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
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<UserAuthenticatedResponse> Authenticate(UserAuthenticateCommand command)
        {
            return await _mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<bool> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}