

namespace ePieHut.Services.Interfaces
{
    public interface IServices<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);







    }
}
