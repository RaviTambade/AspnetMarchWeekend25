using QuickKart.Domain.Entities;
using QuickKart.Interfaces;

namespace QuickKart.Infrastructure.Repositories {
    public class OrderRepository : IOrderRepository {
        private readonly List<Order> _orders = new();

        public Task AddAsync(Order order) {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<Order?> GetByIdAsync(Guid id) {
            return Task.FromResult(_orders.FirstOrDefault(o => o.Id == id));
        }
    }
}
