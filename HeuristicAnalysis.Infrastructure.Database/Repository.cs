using System.Data.Entity;
using System.Linq;

namespace HeuristicAnalysis.Infrastructure.Database
{
    public class Repository<TEntity> where TEntity : class
    {
        public AppContext Context;
        public DbSet<TEntity> DbSet;

        public Repository(AppContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public AppContext HomeContext()
        {
            return Context;
        }

        public IQueryable<TEntity> Get()
        {
            return DbSet.AsQueryable();
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Update(TEntity entity, int id)
        {
            var temp = Get(id);
            if (temp == null) return;
            Context.Entry(temp).CurrentValues.SetValues(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var temp = Get(id);
            if (temp == null) return;
            DbSet.Remove(temp);
            Context.SaveChanges();
        }

    }
}
