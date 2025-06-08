using MediatR;

namespace QuickKart.Domain.Events {
    public class OrderPlacedEvent : INotification {
        public Guid OrderId { get; set; }
    }
}
