namespace BankRequest.DataAccess.Repository.Ef
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        protected IQueryable<TEntity> Queryable 
            => _context.Set<TEntity>();
    }
}
