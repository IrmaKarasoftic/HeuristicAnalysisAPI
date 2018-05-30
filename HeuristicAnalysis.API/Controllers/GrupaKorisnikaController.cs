using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class GrupaKorisnikaController : HomeController<GrupaKorisnika>
    {
        public GrupaKorisnikaController(Repository<GrupaKorisnika> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var grupe = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
                return Ok(grupe);
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
        public IHttpActionResult Post(GrupaKorisnikaModel model)
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
        public IHttpActionResult Put(GrupaKorisnikaModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var grupa = Repository.Get(id);
                if (grupa == null) return NotFound();
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
                var grupa = Repository.Get(id);
                if (grupa == null) return NotFound();
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