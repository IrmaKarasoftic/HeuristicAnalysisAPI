using System;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class AplikacijeController : HomeController<Aplikacija>
    {
        public AplikacijeController(Repository<Aplikacija> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var aplikacije = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
                return Ok(aplikacije);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var analiza = Repository.Get(id);
                return Ok(analiza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(AplikacijaModel model)
        {
            try
            {
                if (model == null) return BadRequest("Model is null");
                Repository.Insert(Parser.Create(model, Repository.HomeContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(AplikacijaModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var application = Repository.Get(id);
                if (application == null) return NotFound();
                Repository.Update(Parser.Create(model, Repository.HomeContext()), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var aplikacija = Repository.Get(id);
                if (aplikacija == null) return NotFound();
                Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}