using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using IMS.Models;

namespace IMS.DataAccess.Repository
{
    public class StoreRepository : Repository<Store>, IStoreRepostiory
    {
        private readonly ApplicationDbContext _db;
        public StoreRepository(ApplicationDbContext db) : base(db)
        {

            _db = db;
        }

        public void Update(Store obj)
        {
            _db.Stores.Update(obj);
        }
    }
}
