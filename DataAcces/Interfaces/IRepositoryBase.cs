﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface  IRepositoryBase<T> 
    {

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        IQueryable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}