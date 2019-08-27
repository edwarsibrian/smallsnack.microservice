using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Responses;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class AuthenticateUserHandler : IRequestHandler<UserAuthenticateCommand, User>
    {
        private readonly IUserService _userService;

        public AuthenticateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(UserAuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Authenticate(request.UserName, request.Password);
        }
    }
}