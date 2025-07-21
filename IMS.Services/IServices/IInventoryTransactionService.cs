using IMS.Models;

namespace IMS.Services.IServices
{
    public interface IInventoryTransactionService
    {
        void StockIn(int productId, int storeId, int quality, string? note = null, string? performedBy = null);
        void StockOut(int productId, int storeId, int quality, string? note = null, string? performedBy = null);

        IEnumerable<InventoryTransaction> GetAll();

    }
}
