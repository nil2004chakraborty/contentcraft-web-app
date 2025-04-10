﻿namespace Blog.DAL.IRepository
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        void SaveChangesManaged();
        T GetById(int id);
    }
}
