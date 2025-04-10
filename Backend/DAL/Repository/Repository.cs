using Blog.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Repository
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext EMDBContext = null;

        public Repository(Tcontext context)
        {
            this.EMDBContext = context;
        }

        public bool Add(T entity)
        {
            this.EMDBContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            this.EMDBContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            this.EMDBContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            this.EMDBContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return EMDBContext.Set<T>().Find(id);
        }

    }
}
