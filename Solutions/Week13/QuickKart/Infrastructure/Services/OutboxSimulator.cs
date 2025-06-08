using MediatR;
using QuickKart.Domain.Events;

namespace QuickKart.Infrastructure.Services {
    public class OutboxSimulator : INotificationHandler<OrderPlacedEvent> {
        public Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken) {
            Console.WriteLine($"📬 [OUTBOX] Order Confirmation Sent for Order ID: {notification.OrderId}");
            return Task.CompletedTask;
        }
    }
}
