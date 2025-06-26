namespace IMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category {  get; }
        IStoreRepostiory Store { get; }
        IUnitRepository Unit { get; }

        void Save();
    }
}
