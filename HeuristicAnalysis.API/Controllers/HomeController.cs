using HeuristicAnalysis.Infrastructure.Database;
using System.Web.Http;

namespace HeuristicAnalysis.API.Controllers
{
    public class HomeController<E> : ApiController where E : class
    {
        private ModelFactory _modelFactory;
        private EntityParser _entityParser;

        public HomeController(Repository<E> repo)
        {
            Repository = repo;
        }
        protected Repository<E> Repository { get; }


        protected ModelFactory Factory => _modelFactory ?? (_modelFactory = new ModelFactory());

        protected EntityParser Parser => _entityParser ?? (_entityParser = new EntityParser());
    }
}
