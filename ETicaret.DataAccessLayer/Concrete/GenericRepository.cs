using ETicaret.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ETicaret.DataAccessLayer.Concrete
{
    public class GenericRepository<T, TContext> : IGenericRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public virtual void Create(T entity)
        {
            using (var ctx = new TContext())
            {
                ctx.Set<T>().Add(entity);
                ctx.SaveChanges();
            }
        }

        public virtual void Delete(T entity)
        {
            using (var ctx = new TContext())
            {
                ctx.Set<T>().Remove(entity);
                ctx.SaveChanges();
            }
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var ctx = new TContext())
            {
                return filter == null
                    ? ctx.Set<T>().ToList()
                    : ctx.Set<T>().Where(filter).ToList();
            }
        }

        public virtual T GetById(int id)
        {
            using (var ctx = new TContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }

        public virtual T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var ctx = new TContext())
            {
                return ctx.Set<T>().Where(filter).SingleOrDefault();
            }
        }

        public virtual void Update(T entity)
        {
            using (var ctx = new TContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
