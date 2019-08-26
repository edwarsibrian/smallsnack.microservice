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

namespace SmallSnack.Microservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppSettings _appSettings;

        public UserController(IMediator mediator, IOptions<AppSettings> appSettings)
        {
            _mediator = mediator;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserAuthenticateCommand command)
        {
            var userResponse = await _mediator.Send(command);

            if (userResponse == null)
                throw new Exception("Username or password is incorrect");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userResponse.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            userResponse.Token = tokenString;

            return Ok(new
            {
                Id = userResponse.Id,
                Username = userResponse.UserName,
                FirstName = userResponse.FirstName,
                LastName = userResponse.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<bool> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}