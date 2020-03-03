using StarshipBattle.Data.Entites;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StarshipBattle.Data
{
    public interface IRepository
    {
        IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : class, IEntity;

        IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity;

        TEntity Get<TEntity>(int id)
            where TEntity : class, IEntity;

        int Add<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Edit<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Remove<TEntity>(TEntity entity)
            where TEntity : class, IEntity;
    }
}
