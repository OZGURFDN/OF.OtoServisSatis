using OtoServisSatis.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using OtoServisSatis.DAL;

namespace OtoServisSatis.BL.Repositories
{
    public class Repository<T> : IRepsitory<T> where T : class, IEntity, new()
    {
        private DatabaseContext context;
        private DbSet<T> dbset;

        public Repository()
        {
            if (context == null)
            {
                context = new DatabaseContext();
                dbset = context.Set<T>();
            }
        }
        public int Add(T entity)
        {
            dbset.Add(entity);
            return context.SaveChanges();
        }
        public int Delete(int id)
        {
            dbset.Remove(Find(id));
            return Save();
        }
        public T Find(int id)
        {
            return dbset.Find(id);
        }
        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbset.FirstOrDefault(expression);
        }
        public List<T> GetAll()
        {
            return dbset.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbset.Where(expression).ToList();
        }

        public int Update(T entity)
        {
            dbset.AddOrUpdate(entity);
            return Save();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }

}