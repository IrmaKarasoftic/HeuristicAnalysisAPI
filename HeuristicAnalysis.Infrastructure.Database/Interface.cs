using System.Linq;

namespace HeuristicAnalysis.Infrastructure.Database
{
    public interface INterface<TEntity>
    {
        AppContext HomeContext();
        IQueryable<TEntity> Get();
        TEntity Get(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity, int id);
        void Delete(int id);
    }
}
