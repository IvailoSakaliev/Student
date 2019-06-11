using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAcsess.Models;
using DataAcsess.Repository;

namespace StudentSystem.Servise
{
    public interface IGenericServise<TEntity> where TEntity : BaseModel, new()
    {
        GenericRepository<TEntity> _repo { get; set; }

        void Delete(Expression<Func<TEntity, bool>> filter);
        void Delete(TEntity entity);
        void DeleteById(int id);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        TEntity GetByID(int? id);
        TEntity GetLastElement();
        void Save(TEntity entity);
    }
}