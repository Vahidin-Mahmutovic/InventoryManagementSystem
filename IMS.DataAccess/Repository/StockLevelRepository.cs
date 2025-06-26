using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using IMS.Models;

namespace IMS.DataAccess.Repository
{
    public class StockLevelRepository : Repository<StockLevel>, IStockLevelRepository
    {
        private readonly ApplicationDbContext _db;
        public StockLevelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(StockLevel obj)
        {
            _db.StockLevels.Update(obj);
        }
    }
}
