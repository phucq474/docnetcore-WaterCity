namespace WaterCity.Contract.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChange();
        Task<int> SaveChangeAsync();
    }
}
