using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using Version = HeuristicAnalysis.Infrastructure.Database.Entities.Version;

namespace HeuristicAnalysis.API.Controllers
{
    public class AnalysisController : HomeController<Analysis>
    {
        public AnalysisController(Repository<Analysis> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var analisysList = Repository.Get().ToList().Select(x => Factory.CreateAnalysisModel(x, Repository.HomeContext())).ToList();
                return Ok(analisysList);
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
                var context = Repository.HomeContext();
                var form = Factory.CreateAnalysisApplicationFormModel(new Repository<Analysis>(context).Get(id));
                return Ok(form);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("api/Analysis/user/{id:int}")]
        public IHttpActionResult GetAnalysesByUserId(int id)
        {
            try
            {
                var context = Repository.HomeContext();
                var usersRepo = new Repository<User>(context);
                var user = usersRepo.Get(id);
                var groupIds = context.UserGroups.Where(g => g.Users.Select(userr => userr.Id).Contains(user.Id)).Select(ug => ug.Id).ToList();
                var analysis = context.AnalysisApplicationForms.Where(f => f.Groups.Any(g => groupIds.Contains(g.Id))).ToList();
                var analysisList = analysis.Select(a => Factory.CreateAnalysisModel(a, context, user)).Distinct();
                return Ok(analysisList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(CreateAnalysisModel model)
        {
            try
            {
                var context = Repository.HomeContext();
                var heuristicsRepo = new Repository<Heuristic>(context);
                var groupRepo = new Repository<UserGroup>(context);
                var versionRepo = new Repository<Version>(context);
                if (model == null) return BadRequest("Model is null");

                var version = new Repository<Version>(context).Get(model.VersionId);
                var groups = model.Groups.Where(h => h.Checked).Select(g => Parser.CreateGroupWithUsers(g, context)).ToList();
                var heuristics = model.Heuristics.Where(h => h.Checked).ToList();
                foreach (var heuristic in heuristics)
                {
                    var h = heuristicsRepo.Get(heuristic.Id);
                    version.AnalysisApplicationForm.Heuristics.Add(h);
                }
                var nielsen = heuristicsRepo.Get().Where(x => x.Id <= 10).ToList();
                version.AnalysisApplicationForm.Heuristics = version.AnalysisApplicationForm.Heuristics.Concat(nielsen).ToList();
                foreach (var group in groups)
                {
                    var g = groupRepo.Get(group.Id);
                    version.AnalysisApplicationForm.Groups.Add(g);
                }
                versionRepo.Update(version, version.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(AnalysisModel model, int id)
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
                var analisys = Repository.Get(id);
                if (analisys == null) return NotFound();
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