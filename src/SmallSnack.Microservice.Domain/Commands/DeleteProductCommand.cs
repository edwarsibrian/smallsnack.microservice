using MediatR;

namespace SmallSnack.Microservice.Domain.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}