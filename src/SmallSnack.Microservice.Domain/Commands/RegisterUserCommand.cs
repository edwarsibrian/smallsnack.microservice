using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmallSnack.Microservice.Domain.Enums;

namespace SmallSnack.Microservice.Domain.Commands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        [FromBody]
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string Role { get; set; }
    }
}