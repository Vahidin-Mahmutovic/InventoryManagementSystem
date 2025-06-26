using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;

namespace IMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IStoreRepostiory Store { get; private set; }
        public IUnitRepository Unit { get; private set; }
        public IStockLevelRepository StockLevel { get; private set; }
        public IProductRepository Product { get; private set; }
        public IInventoryTransactionRepository InventoryTransaction { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Store = new StoreRepository(_db);
            Unit = new UnitRepository(_db);
            StockLevel = new StockLevelRepository(_db);
            Product = new ProductRepository(_db);
            InventoryTransaction = new InventoryTransactionRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
