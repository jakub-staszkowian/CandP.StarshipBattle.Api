using Microsoft.EntityFrameworkCore;
using StarshipBattle.Data.Entites;
using StarshipBattle.Data.EntityFramework.Maps;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace StarshipBattle.Data.EntityFramework
{
    internal class StarshipBattleContext : DbContext, IRepository
    {
        public StarshipBattleContext(DbContextOptions<StarshipBattleContext> options)
            : base(options)
        {
        }

        public DbSet<Starship> Starships { get; set; }

        public void Edit<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return Set<TEntity>()
                .Where(predicate);
        }

        public TEntity Get<TEntity>(int id) where TEntity : class, IEntity
        {
            return Set<TEntity>()
                .FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }

        int IRepository.Add<TEntity>(TEntity entity)
        {
            Entry(entity).State = EntityState.Added;
            SaveChanges();
            return entity.Id;
        }

        void IRepository.Remove<TEntity>(TEntity entity)
        {
            Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StarshipMap());
        }
    }
}
