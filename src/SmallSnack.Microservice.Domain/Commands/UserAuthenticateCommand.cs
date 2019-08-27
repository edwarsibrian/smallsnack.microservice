using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmallSnack.Microservice.Domain.Entities;
using SmallSnack.Microservice.Domain.Responses;

namespace SmallSnack.Microservice.Domain.Commands
{
    public class UserAuthenticateCommand : IRequest<User>
    {
        [FromBody]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}