namespace QuickKart.Interfaces {
    public interface IUnitOfWork {
        Task CommitAsync();
    }
}
