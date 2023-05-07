namespace Domain.Interfaces
{
    interface IRepository<TEntity>
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Remove(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
