using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Repository;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Eventos.IO.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity<TEntity>
    {
        protected EventsContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(EventsContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking()
                .Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.AsNoTracking()
                .FirstOrDefault(t => t.Id == id);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }
    }
}
