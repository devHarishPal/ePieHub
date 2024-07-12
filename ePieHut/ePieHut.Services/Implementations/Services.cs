using ePieHut.Repositories.Interfaces;
using ePieHut.Services.Interfaces;
using System.Linq;

namespace ePieHut.Services.Implementations
{
    public class Services<TEntity> : IServices<TEntity> where TEntity : class
    {
        public readonly IRepository<TEntity> repo;


        public Services(IRepository<TEntity> _repo)
        {

            repo = _repo;
            
        }


        public void Add(TEntity entity)
        {
           repo.Add(entity);
            repo.SaveChanges();
        }

        public void Delete(int Id)
        {
            repo?.Delete(Id);
            repo.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repo.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repo.FetchById(id);
        }

        public void Update(TEntity entity)
        {
            repo.Update(entity);
            repo.SaveChanges();
        }
    }
}
