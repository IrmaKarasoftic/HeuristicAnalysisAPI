using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using AppContext = HeuristicAnalysis.Infrastructure.Database.AppContext;

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
                var analysis = Parser.CreateAnalysis(model, context);
                var analysisModel = Factory.CreateAnalysisModel(analysis, context);
                return Ok(analysisModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(CompleteAnalysisDetails model, int id)
        {
            var context = Repository.HomeContext();
            var heuristicRepo = new Repository<AnsweredQuestion>(context);
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                foreach (var heuristic in model.Heuristics)
                {
                    var dbHeuristics = Repository.Context.AnsweredQuestions.Find(heuristic.Id);
                    foreach (var answer in heuristic.Answers)
                    {
                        var dbAnswer = Repository.Context.Answers.Find(answer.Id);
                        if (dbAnswer != null)
                        {
                            dbAnswer.Description = answer.Description;
                            dbAnswer.Location = answer.Location;
                            dbAnswer.Level = (int.Parse(answer.Level));
                            dbAnswer.Recommendation = answer.Recommendation;
                            dbAnswer.Images = answer.Images.Select(Parser.Create).ToList();
                        }
                        else
                        {
                            var a = new Answer()
                            {
                                Description = answer.Description,
                                Location = answer.Location,
                                Level = (int.Parse(answer.Level)),
                                Recommendation = answer.Recommendation,
                                Images = answer.Images.Select(Parser.Create).ToList()
                            };
                            dbHeuristics.Answers.Add(a);
                        }
                    }
                    heuristicRepo.Update(dbHeuristics, dbHeuristics.Id);
                }

                var ids = model.Heuristics.Select(x => x.Id).ToList();
                var answersFromDb = heuristicRepo.Context.AnsweredQuestions.Where(x => ids.Contains(x.Id));
                var answersFromUi = model.Heuristics.ToList();
                foreach (var dbAnswer in answersFromDb)
                {
                    foreach (var answer in dbAnswer.Answers)
                    {
                        var dba = Repository.Context.Answers.Find(answer.Id);
                        var existingAnswer = answersFromUi.FirstOrDefault(answerModel => answerModel.Answers.Any(ans => ans.Id == dba.Id));
                        if (dba != null && existingAnswer == null)
                        {
                            dbAnswer.Answers.Remove(dba);
                        }
                    }
                }
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