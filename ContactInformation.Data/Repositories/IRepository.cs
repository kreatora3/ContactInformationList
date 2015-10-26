namespace ContactInformation.Data.Repositories
{
    using System.Linq;

    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(object id);

        void Add(TEntity entity);
        
        void Delete(TEntity entity);

        void Delete(object id);

        void Update(TEntity entity);

        void SaveChanges();
    }
}
