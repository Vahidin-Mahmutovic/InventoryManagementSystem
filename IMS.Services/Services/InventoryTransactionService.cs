using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using IMS.Services.IServices;
using IMS.Utility.Enums;

namespace IMS.Services.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<InventoryTransaction> GetAll()
        {
            return _unitOfWork.InventoryTransaction.GetAll(includeProperties:"Product,Store");
        }


        public void StockIn(int productId, int storeId, int quantity, string? note = null, string? performedBy = null)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");

            var transaction = new InventoryTransaction
            {
                ProductId = productId,
                StoreId = storeId,
                Quantity = quantity,
                TransactionType = TransactionType.StockIn,
                Date = DateTime.Now,
                Note = note,
                PerformedBy = performedBy
            };

            _unitOfWork.InventoryTransaction.Add(transaction);
            _unitOfWork.Save();
            
        }

        public void StockOut(int productId, int storeId, int quantity, string? note = null, string? performedBy = null)
        {
            if(quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");

            var transactions = _unitOfWork.InventoryTransaction
                .GetAll(t => t.ProductId == productId && t.StoreId == storeId);

            int currentStock = transactions
                .Where(t => t.TransactionType == TransactionType.StockIn)
                .Sum(t => t.Quantity)
                -
                transactions
                .Where(t => t.TransactionType == TransactionType.StockOut)
                .Sum(t => t.Quantity);

            if (currentStock < quantity)
                throw new InvalidOperationException("Not enough stock avaliable.");

            var transaction = new InventoryTransaction
            {
                ProductId = productId,
                StoreId = storeId,
                Quantity = quantity,
                TransactionType = TransactionType.StockOut,
                Date = DateTime.Now,
                Note = note,
                PerformedBy = performedBy
            };

            _unitOfWork.InventoryTransaction.Add(transaction);
            _unitOfWork.Save();
            
        }
    }
}
