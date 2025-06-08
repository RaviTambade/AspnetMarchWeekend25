using MediatR;

namespace QuickKart.Commands {
    public class PlaceOrderCommand : IRequest<Guid> {
        public string CustomerName { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new();
    }
}
