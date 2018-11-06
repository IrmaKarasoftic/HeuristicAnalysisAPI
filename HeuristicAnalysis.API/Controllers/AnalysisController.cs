using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

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
                var analisysList = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
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
                var analysisModel = Factory.CreateCompleteAnalysisDetailsModel(id, Repository.HomeContext());
                return Ok(analysisModel);
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
                var groupIds = context.UserGroups.Where(g => g.UserId == id).Select(group => group.Id).ToList();
                var analyses = context.AnalysesGroups.Where(a => groupIds.Contains(a.GroupId)).Select(analysis => analysis.AnalysisId).ToList();

                var analysisList = new List<AnalysisModel>();
                foreach (var analysisId in analyses)
                {
                    var appAnalyses = context.AnalysesApplication.Where(a => a.Id == analysisId).ToList();
                    foreach (var analysisApplication in appAnalyses)
                    {
                        var model = context.Analysis.Find(analysisApplication.Id);
                        analysisList.Add(Factory.CreateAnalysisModel(model, analysisApplication.VersionId, context));
                    }
                }
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
                if (model == null) return BadRequest("Model is null");
                var analysis = new AnalysisApplication()
                {
                    ApplicationId = model.AppId,
                    VersionId = model.VersionId
                };
                var context = Repository.HomeContext();
                new Repository<AnalysisApplication>(context).Insert(analysis);
                var groups = model.Groups.Where(g => g.Checked);
                foreach (var groupModel in groups)
                {
                    var ag = new AnalysesGroups()
                    {
                        GroupId = groupModel.Id,
                        AnalysisId = analysis.Id
                    };
                    new Repository<AnalysesGroups>(context).Insert(ag);
                }

                var heuristics = model.Heuristics.Where(g => g.Checked);
                foreach (var heuristic in heuristics)
                {
                    var ah = new AnalysesHeuristics()
                    {
                        HeuristicId = heuristic.Id,
                        AnalysisId = analysis.Id
                    };
                    new Repository<AnalysesHeuristics>(context).Insert(ah);
                }
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