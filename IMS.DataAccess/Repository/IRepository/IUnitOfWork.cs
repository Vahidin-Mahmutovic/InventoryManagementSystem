namespace IMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category {  get; }
        IStoreRepostiory Store { get; }
        IUnitRepository Unit { get; }
        IProductRepository Product { get; }
        IInventoryTransactionRepository InventoryTransaction { get; }

        void Save();
    }
}
