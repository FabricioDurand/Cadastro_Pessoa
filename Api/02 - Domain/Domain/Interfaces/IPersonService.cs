using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IPersonService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
    }
}
