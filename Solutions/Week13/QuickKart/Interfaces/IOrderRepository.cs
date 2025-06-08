using QuickKart.Domain.Entities;

namespace QuickKart.Interfaces {
    public interface IOrderRepository {
        Task AddAsync(Order order);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
