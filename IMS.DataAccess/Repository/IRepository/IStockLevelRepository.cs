using IMS.Models;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IStockLevelRepository : IRepository<StockLevel>
    {
        void Update(StockLevel obj);
    }
}
