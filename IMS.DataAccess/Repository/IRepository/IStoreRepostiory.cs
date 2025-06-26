using IMS.Models;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IStoreRepostiory : IRepository<Store>
    {
        void Update(Store obj);
    }
}
