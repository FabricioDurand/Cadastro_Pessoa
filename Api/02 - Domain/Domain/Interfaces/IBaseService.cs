﻿using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        void Delete(int id);
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Update<TValidator> (TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
