using MediatR;
using QuickKart.Domain.Entities;
using QuickKart.Interfaces;

namespace QuickKart.Queries {
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?> {
        private readonly IOrderRepository _repo;

        public GetOrderByIdHandler(IOrderRepository repo) {
            _repo = repo;
        }

        public Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) {
            return _repo.GetByIdAsync(request.OrderId);
        }
    }
}
