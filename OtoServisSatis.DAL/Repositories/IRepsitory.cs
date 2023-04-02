﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OtoServisSatis.DAL.Repositories
{
    public interface IRepsitory<T>
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        T Find(int id);
        T Get(Expression<Func<T, bool>> expression);
        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}