
namespace IMS.Models.ViewModels
{
    public class StockLevelVM
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }
    }
}
