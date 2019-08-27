using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Helpers;
using SmallSnack.Microservice.Domain.Responses;
using SmallSnack.Microservice.Services;

namespace SmallSnack.Microservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AccountService _accountService;
        
        public UserController(IMediator mediator, AccountService accountService)
        {
            _mediator = mediator;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthenticateCommand command)
        {
            var user = await _mediator.Send(command);

            if (user == null)
            {
                return Unauthorized();
            }

            var jwtToken = _accountService.Login(user.Id, user.Role);

            return Ok(jwtToken);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<bool> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}