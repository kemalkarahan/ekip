using ekip.Core.DataAccess.Abstract;
using ekip.Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ekip.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity,new()
        where TContext : DbContext, new()
    {
        public async Task Insert(TEntity entity)
        {
            using (var context = new TContext())
            {
                var insertedEntity = context.Entry(entity);
                insertedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> Check(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().AnyAsync(filter);
            }
        }

        public async Task<TEntity> Retrieve(Expression<Func<TEntity, bool>> filter)
        {
            

            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<IList<TEntity>> RetrieveAll(Expression<Func<TEntity, bool>> filter = null)
        {

            using (var context = new TContext())
            {
                return filter != null ? await context.Set<TEntity>().Where(filter).ToListAsync() : await context.Set<TEntity>().ToListAsync();
            }
        }
    }
}
