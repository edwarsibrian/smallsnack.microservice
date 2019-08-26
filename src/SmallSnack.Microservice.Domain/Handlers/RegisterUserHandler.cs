using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SmallSnack.Microservice.Domain.Commands;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Services;

namespace SmallSnack.Microservice.Domain
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.UserName,
                IsAdmin = request.IsAdmin
            };

            return await _userService.Create(user, request.Password) != null;
        }
    }
}