using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repository
{
    public  class BaseReporitory<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MySqlContext _mySqlContext;

        public BaseReporitory(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _mySqlContext.Set<TEntity>().Add(obj);
            _mySqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _mySqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _mySqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _mySqlContext.Set<TEntity>().Remove(GetById(id));
            _mySqlContext.SaveChanges();
        }

        public List<TEntity> GetAll() => _mySqlContext.Set<TEntity>().ToList();

        public TEntity GetById(int id) => _mySqlContext.Set<TEntity>().Find(id);
    }
}
