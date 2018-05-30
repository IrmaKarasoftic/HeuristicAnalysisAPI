using HeuristicAnalysis.Infrastructure.Database;
using System.Web.Http;

namespace HeuristicAnalysis.API.Controllers
{
    public class HomeController<TE> : ApiController where TE : class
    {
        private ModelFactory _modelFactory;
        private EntityParser _entityParser;

        public HomeController(Repository<TE> repo)
        {
            Repository = repo;
        }
        protected Repository<TE> Repository { get; }


        protected ModelFactory Factory => _modelFactory ?? (_modelFactory = new ModelFactory());

        protected EntityParser Parser => _entityParser ?? (_entityParser = new EntityParser());
    }
}
