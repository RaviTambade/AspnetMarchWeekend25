using MediatR;
using QuickKart.Domain.Entities;
using QuickKart.Domain.Events;
using QuickKart.Interfaces;

namespace QuickKart.Commands {
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, Guid> {
        private readonly IOrderRepository _repo;
        private readonly IUnitOfWork _unit;
        private readonly IMediator _mediator;

        public PlaceOrderHandler(IOrderRepository repo, IUnitOfWork unit, IMediator mediator) {
            _repo = repo;
            _unit = unit;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken) {
            var order = new Order {
                CustomerName = request.CustomerName,
                Items = request.Items
            };

            await _repo.AddAsync(order);
            await _unit.CommitAsync();
            await _mediator.Publish(new OrderPlacedEvent { OrderId = order.Id });

            return order.Id;
        }
    }
}
