using ePieHut.Entities;
using ePieHut.Repositories.Interfaces;


namespace ePieHut.Repositories.Implentations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext context;

        public Repository(AppDbContext dbContext)
        {
         
            context = dbContext;

        }



        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);

            }

        }

        public TEntity FetchById(int id)
        {
            var entity = context.Set<TEntity>().Find(id);

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public int SaveChanges()
        {

            return context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
