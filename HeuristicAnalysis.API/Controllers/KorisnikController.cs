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
    public class KorisnikController : HomeController<Korisnik>
    {
        public KorisnikController(Repository<Korisnik> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var korisnici = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
                return Ok(korisnici);
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
        public IHttpActionResult Post(Korisnik model)
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
        public IHttpActionResult Put(Korisnik model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var korisnik = Repository.Get(id);
                if (korisnik == null) return NotFound();
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
                var korisnik = Repository.Get(id);
                if (korisnik == null) return NotFound();
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