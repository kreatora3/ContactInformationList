namespace ContactInformation.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DbContext context;
        private IDbSet<TEntity> set;
       
        // To be removed when Ninject is tuned.
        public EntityFrameworkRepository()
            : this(new ContactDbContext())
        {
        }

        public EntityFrameworkRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<TEntity>();
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return this.set;
        }

        public TEntity GetById(object id)
        {
            return this.set.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Delete(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            this.Delete(this.GetById(id));
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
