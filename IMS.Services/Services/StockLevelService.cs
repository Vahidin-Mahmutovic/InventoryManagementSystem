using IMS.DataAccess.Repository.IRepository;
using IMS.Services.IServices;
using IMS.Utility.Enums;

using IMS.Models.ViewModels;

namespace IMS.Services.Services
{
    public class StockLevelService : IStockLevelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockLevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetCurrentStock(int productId, int storeId)
        {
            var transactions = _unitOfWork.InventoryTransaction
                .GetAll(t => t.ProductId == productId && t.StoreId == storeId);

            int quantityIn = transactions
                .Where(t => t.TransactionType == TransactionType.StockIn)
                .Sum(t => t.Quantity);

            int quantityOut = transactions
                .Where(t => t.TransactionType == TransactionType.StockOut)
                .Sum(t => t.Quantity);

            return quantityIn - quantityOut;
        }

        public IEnumerable<StockLevelVM> GetAll()
        {
            var transactions = _unitOfWork.InventoryTransaction
                .GetAll(includeProperties: "Product,Store")
                .ToList(); 

            var groupedTransactions = transactions
                .GroupBy(t => new { t.ProductId, t.StoreId })
                .Select(g => new StockLevelVM
                {
                    ProductId = g.Key.ProductId,
                    StoreId = g.Key.StoreId,
                    ProductName = g.First().Product?.Name ?? "",
                    StoreName = g.First().Store?.Name ?? "",
                    Quantity = g.Where(x => x.TransactionType == TransactionType.StockIn).Sum(x => x.Quantity)
                             - g.Where(x => x.TransactionType == TransactionType.StockOut).Sum(x => x.Quantity)
                });

            return groupedTransactions.ToList();
        }

    }
}
