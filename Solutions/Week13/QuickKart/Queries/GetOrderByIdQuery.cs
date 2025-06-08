using MediatR;
using QuickKart.Domain.Entities;

namespace QuickKart.Queries {
    public class GetOrderByIdQuery : IRequest<Order?> {
        public Guid OrderId { get; set; }
    }
}
