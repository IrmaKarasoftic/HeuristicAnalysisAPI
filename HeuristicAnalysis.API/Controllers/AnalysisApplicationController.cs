using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class AnalysisApplicationController : HomeController<AnalysisApplicationForm>
    {
        public AnalysisApplicationController(Repository<AnalysisApplicationForm> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var applications = Repository.Get().ToList();
                return Ok(applications);
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
                var application = Repository.Get(id);
                return Ok(application);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(FillOutAnalysisModel model)
        {
            try
            {
                var context = Repository.HomeContext();
                if (model == null) return BadRequest("Model is null");
                var analysisForm = new AnalysisApplicationForm();
                var heuristics = new List<Heuristic>();
                foreach (var heuristic in model.Heuristics)
                {
                    var qa = Parser.Create(heuristic);
                    //heuristics.Add(qa);
                }

                analysisForm.Heuristics = heuristics;
                //Repository.Insert(Parser.Create(model, Repository.HomeContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(ApplicationModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var application = Repository.Get(id);
                if (application == null) return NotFound();
                //Repository.Update(Parser.Create(model, Repository.HomeContext()), id);
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
                var application = Repository.Get(id);
                if (application == null) return NotFound();
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