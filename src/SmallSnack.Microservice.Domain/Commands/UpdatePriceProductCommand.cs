using MediatR;

namespace SmallSnack.Microservice.Domain.Commands
{
    public class UpdatePriceProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public double Price { get; set; }
    }
}