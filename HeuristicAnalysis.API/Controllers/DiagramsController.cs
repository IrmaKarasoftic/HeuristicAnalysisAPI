using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class DiagramsController : HomeController<Analysis>
    {
        public DiagramsController(Repository<Analysis> repo) : base(repo) { }

        [HttpGet]
        [Route("api/Diagrams/{id:int}")]
        public IHttpActionResult GetByVersionId(int id)
        {
            try
            {
                var context = Repository.HomeContext();
                var answerRepository = new Repository<Answer>(context);
                var allAnswers = new List<Answer>();
                var report = new ReportModel();
                var allQA = Repository.Get().Where(x => x.Version.Id == id).Select(y => y.QuestionsAndAnswers).ToList();
                var listOfQuestionAnswerIds = new List<int>();
                foreach (var item in allQA)
                {
                    foreach (var answeredQuestion in item)
                    {
                        listOfQuestionAnswerIds.Add(answeredQuestion.Id);
                    }
                }
                allAnswers.AddRange(answerRepository.Get().Where(x => listOfQuestionAnswerIds.Contains(x.QuestionAnswerId) && x.Answered));
                var diagramModel = new DiagramModel()
                {
                    NumberOfAnswers = allAnswers.Count(x => x.Level != 0),
                    HighLevel = allAnswers.Count(x => x.Level == 3),
                    MediumLevel = allAnswers.Count(x => x.Level == 2),
                    LowLevel = allAnswers.Count(x => x.Level == 1),
                    NoLevel= allAnswers.Count(x => x.Level == 0)
                };
                report.DiagramModel = diagramModel;
                report.Answers = allAnswers.OrderByDescending(x => x.Level).ToList();
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}