using MediatR;

namespace SmallSnack.Microservice.Domain.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}