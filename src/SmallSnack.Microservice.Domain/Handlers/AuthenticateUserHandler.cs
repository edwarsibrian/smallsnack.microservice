using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Responses;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class AuthenticateUserHandler : IRequestHandler<UserAuthenticateCommand, UserAuthenticatedResponse>
    {
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserAuthenticatedResponse> Handle(UserAuthenticateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.Authenticate(request.UserName, request.Password);

            if (user == null)
            {
                throw new Exception("Username or password is incorrect");
            }

            return new UserAuthenticatedResponse
            {
                UserName = user.Username
            };
        }
    }
}