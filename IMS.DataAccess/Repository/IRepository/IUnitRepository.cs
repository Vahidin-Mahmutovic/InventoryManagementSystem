using IMS.Models;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IUnitRepository : IRepository<Unit>
    {
        void Update(Unit obj);
    }
}
