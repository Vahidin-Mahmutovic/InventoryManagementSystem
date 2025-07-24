using IMS.Models.ViewModels;


namespace IMS.Services.IServices
{
    public interface IStockLevelService
    {
        int GetCurrentStock(int productId, int storeId);
        IEnumerable<StockLevelVM> GetAll();
    }
}
