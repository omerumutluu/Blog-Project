﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAllWithFilter(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
