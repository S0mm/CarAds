using System.Threading.Tasks;

namespace CarAds.Data.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}