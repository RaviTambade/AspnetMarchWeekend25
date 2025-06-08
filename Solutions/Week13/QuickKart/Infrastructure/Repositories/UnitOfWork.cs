using QuickKart.Interfaces;

namespace QuickKart.Infrastructure.Repositories {
    public class UnitOfWork : IUnitOfWork {
        public Task CommitAsync() => Task.CompletedTask;
    }
}
