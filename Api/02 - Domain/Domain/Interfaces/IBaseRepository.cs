using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public void Insert (TEntity obj);
        public void Update (TEntity obj);
        public void Delete (int id);
        public List<TEntity> GetAll ();
        public TEntity GetById (int id);
    }
}
