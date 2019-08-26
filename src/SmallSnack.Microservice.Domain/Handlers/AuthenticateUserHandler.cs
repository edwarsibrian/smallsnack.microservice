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

            var userAuthenticateResponse = new UserAuthenticatedResponse();

            if (user != null)
            {
                userAuthenticateResponse.Id = user.Id;
                userAuthenticateResponse.UserName = user.Username;
                userAuthenticateResponse.FirstName = user.FirstName;
                userAuthenticateResponse.LastName = user.LastName;
            }

            return userAuthenticateResponse;
        }
    }
}