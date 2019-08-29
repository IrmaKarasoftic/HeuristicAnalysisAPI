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
                var app = new Repository<Application>(context).Get().FirstOrDefault(x => x.Versions.Any(y =>y.Id == id));
                report.AppName = app.Name;
                report.VersionName = app.Versions.FirstOrDefault(x => x.Id == id).VersionName;
                var allQA = Repository.Get().Where(x => x.Version.Id == id).Select(y => y.QuestionsAndAnswers).ToList();
                var listOfQuestionAnswerIds = new List<int>();
                foreach (var item in allQA)
                {
                    foreach (var answeredQuestion in item)
                    {
                        listOfQuestionAnswerIds.Add(answeredQuestion.Id);
                    }
                }
                allAnswers.AddRange(answerRepository.Get().Where(x => listOfQuestionAnswerIds.Contains(x.QuestionAnswerId) && x.Level != 0));
                var diagramModel = new DiagramModel()
                {
                    NumberOfAnswers = allAnswers.Count(x => x.Level != 0),
                    HighLevel = allAnswers.Count(x => x.Level == 3),
                    MediumLevel = allAnswers.Count(x => x.Level == 2),
                    LowLevel = allAnswers.Count(x => x.Level == 1),
                    NoLevel = allAnswers.Count(x => x.Level == 0)
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

        [HttpGet]
        [Route("api/Diagrams/table/{id:int}")]
        public IHttpActionResult GetTableReport(int id)
        {
            try
            {
                var context = Repository.HomeContext();
                var answerRepository = new Repository<Answer>(context);
                var allAnswers = new List<Answer>();
                var report = new TableReportModel() { TableItems = new List<TableDiagramItem>() };
                var allQA = Repository.Get().Where(x => x.Version.Id == id).Select(y => y.QuestionsAndAnswers).ToList();
                var allHeuristics = new Repository<Heuristic>(context).Get().ToList();
                var listOfQuestionAnswerIds = new List<int>();
                foreach (var item in allQA)
                {
                    foreach (var answeredQuestion in item)
                    {
                        listOfQuestionAnswerIds.Add(answeredQuestion.Id);
                    }
                }
                allAnswers.AddRange(answerRepository.Get().Where(x => listOfQuestionAnswerIds.Contains(x.QuestionAnswerId) && x.Level != 0));
                var grouped = allAnswers.GroupBy(x => x.HeuristicId).ToList();

                var diagramModel = new DiagramModel()
                {
                    NumberOfAnswers = allAnswers.Count(x => x.Level != 0),
                    HighLevel = allAnswers.Count(x => x.Level == 3),
                    MediumLevel = allAnswers.Count(x => x.Level == 2),
                    LowLevel = allAnswers.Count(x => x.Level == 1),
                    NoLevel = allAnswers.Count(x => x.Level == 0),
                };
                foreach (var group in grouped)
                {
                    var heuristicId = group.Select(y => y.HeuristicId).FirstOrDefault();
                    var total = group.Count(x => x.Level != 0);
                    var tableDiagramItemModel = new TableDiagramItem()
                    {
                        Total = total,
                        HighLevel = group.Count(x => x.Level == 3),
                        MediumLevel = group.Count(x => x.Level == 2),
                        LowLevel = group.Count(x => x.Level == 1),
                        Percentage = Math.Round(((double)total / (double)diagramModel.NumberOfAnswers) * 100, 2),
                        DatabaseHeuristicTitle = allHeuristics.FirstOrDefault(x => x.Id == heuristicId).HeuristicTitle
                    };
                    report.TableItems.Add(tableDiagramItemModel);
                }

                report.DiagramModel = diagramModel;
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}