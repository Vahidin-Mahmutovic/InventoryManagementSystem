using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using IMS.Models;

namespace IMS.DataAccess.Repository
{
    public class InventoryTransactionRepository : Repository<InventoryTransaction>, IInventoryTransactionRepository
    {
        private readonly ApplicationDbContext _db;
        public InventoryTransactionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(InventoryTransaction obj)
        {
            _db.InventoryTransactions.Update(obj);
        }
    }
}
