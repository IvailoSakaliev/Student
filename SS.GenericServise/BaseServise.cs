using DataAcsess.Models;
using DataAcsess.Repository;
using DataAcsess.UnitOfWork;
using SS.EncriptServise;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SS.GenericServise
{
    public class BaseServise<TEntity> where TEntity : Parent, new()
    {
        public GenericRepository<TEntity> _repo { get; set; }
        public UnitOfWork unit;
        public EncriptServise.EncriptServises EncriptServise;

        public BaseServise()
        {
            _repo = new GenericRepository<TEntity>(new UnitOfWork());
            this.unit = new UnitOfWork();
            EncriptServise = new EncriptServise.EncriptServises();
        }

        public BaseServise(UnitOfWork unit)
        {
            _repo = new GenericRepository<TEntity>(unit);
            this.unit = unit;
        }
        public List<TEntity> GetAll()
        {
            return (List<TEntity>)_repo.GetAll();
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return (List<TEntity>)_repo.GetAll(filter);
        }
        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, int page = 1, int pageSize = 1)
        {
            return _repo.GetAll(filter, page, pageSize);
        }

        public TEntity GetByID(int? id)
        {
            return _repo.GetByID(id);
        }


        public void Save(TEntity entity)
        {
            try
            {
                _repo.Save(entity);
                this.unit.Commit();
            }
            catch (Exception)
            {
                this.unit.Rowback();
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _repo.Delete(entity);
                this.unit.Commit();
            }
            catch (Exception)
            {
                this.unit.Rowback();
            }
        }
        public void DeleteById(int id)
        {
            try
            {
                _repo.DeleteById(id);
                this.unit.Commit();
            }
            catch (Exception)
            {
                this.unit.Rowback();
            }
        }

    }

}
