using IMS.Models;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IInventoryTransactionRepository : IRepository<InventoryTransaction>
    {
        void Update(InventoryTransaction obj);
    }
}
