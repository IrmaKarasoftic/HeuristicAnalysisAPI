using System;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using HeuristicAnalysis.Infrastructure.Services;

namespace HeuristicAnalysis.API.Controllers
{
    public class AplikacijeController
    {
        [RoutePrefix("api/application")]
        public class ApplicationController : HomeController<Aplikacija>
        {
            public ApplicationController(Repository<Aplikacija> repo) : base(repo){}

            [HttpGet]
            public IHttpActionResult GetAll()
            {
                try
                {
                    var aplikacije = Repository.Get().ToList();
                    return Ok(aplikacije);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

     
        }
    }
}