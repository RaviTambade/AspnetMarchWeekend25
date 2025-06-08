namespace QuickKart.Domain.Entities {
    public class Order {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } = string.Empty;
        public List<string> Items { get; set; } = new();
        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    }
}
