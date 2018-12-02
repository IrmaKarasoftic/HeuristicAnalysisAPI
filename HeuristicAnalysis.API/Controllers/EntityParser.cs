using System;
using System.Collections.Generic;
using System.Linq;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using AppContext = HeuristicAnalysis.Infrastructure.Database.AppContext;
using Version = HeuristicAnalysis.Infrastructure.Database.Entities.Version;

namespace HeuristicAnalysis.API.Controllers
{
    public class EntityParser
    {
        public Analysis Create(AnalysisModel model, Infrastructure.Database.AppContext context)
        {
            //TODO
            return new Analysis()
            {
            };
        }

        public Application Create(ApplicationModel model, Infrastructure.Database.AppContext context)
        {
            return new Application()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url
            };
        }

        public Version Create(VersionModel verzija, Infrastructure.Database.AppContext homeContext)
        {
            return new Version()
            {
                Id = verzija.Id,
                Date = verzija.Date,
                VersionName = verzija.VersionName,
                AnalysisApplicationForm = new AnalysisApplicationForm()
            };
        }

        public UserGroup Create(GroupModel group, Infrastructure.Database.AppContext homeContext)
        {
            return new UserGroup()
            {
                GroupName = group.GroupName,
            };
        }



        public AnsweredQuestion Create(QuestionModel question)
        {
            return new AnsweredQuestion()
            {
                Id = question.Id,
                HeuristicText = question.HeuristicText,
                HeuristicTitle = question.HeuristicTitle,
            };
        }

        public Analysis CreateAnalysis(FillOutAnalysisModel model, AppContext context)
        {
            var analysis = new Analysis()
            {
                Reviewer = context.Users.FirstOrDefault(u => u.Id == model.UserId),
                Version = context.Versions.FirstOrDefault(v => v.AnalysisApplicationForm.Id == model.AnalysisId),
                QuestionsAndAnswers = new List<AnsweredQuestion>()
            };
            var heuristics = context.AnalysisApplicationForms.Find(model.AnalysisId).Heuristics;
            var defaultAnswer = new Answer()
            {
                Description = "",
                Location = "",
                Level = 1,
                Recommendation = ""
            };
            foreach (var heuristic in heuristics)
            {
                var qa = new AnsweredQuestion()
                {
                    HeuristicText = heuristic.HeuristicText,
                    HeuristicTitle = heuristic.HeuristicTitle,
                    Answers = new List<Answer>()
                };
                qa.Answers.Add(defaultAnswer);
                analysis.QuestionsAndAnswers.Add(qa);
            }
            new Repository<Analysis>(context).Insert(analysis);
            return analysis;
        }

        internal HeuristicImage Create(ImageSrc i)
        {
            return new HeuristicImage()
            {
                Img = i.Src
            };
        }

        internal AnsweredQuestion Create(CreateFilledInHeuristicModel heuristic)
        {

            var heuristicImages = new List<HeuristicImage>();
            foreach (var image in heuristic.Images)
            {
                var img = new HeuristicImage
                {
                    Img = image.Src
                };
                heuristicImages.Add(img);
            }
            var qa = new AnsweredQuestion
            {
                Id = heuristic.Id,
                HeuristicTitle = heuristic.HeuristicTitle,
                HeuristicText = heuristic.HeuristicText,
                Images = heuristicImages
            };
            return qa;
        }

        internal Heuristic CreateHeuristicEntity(CreateFilledInHeuristicModel heuristic)
        {
            var qa = new Heuristic
            {
                Id = heuristic.Id,
                HeuristicText = heuristic.HeuristicText,
                HeuristicTitle = heuristic.HeuristicTitle,
            };
            return qa;
        }

        public User Create(UserModel korisnik, Infrastructure.Database.AppContext context)
        {
            return new User()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName,
                Occupation = korisnik.Occupation,
                DateOfBirth = Convert.ToDateTime(korisnik.DateOfBirth)
            };
        }

        internal Heuristic Create(CheckedHeuristicModel he)
        {
            return new Heuristic()
            {
                Id = he.Id,
                HeuristicText = he.HeuristicText,
                HeuristicTitle = he.HeuristicTitle
            };
        }

        public User Create(User korisnik, Infrastructure.Database.AppContext homeContext)
        {
            return new User()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName
            };
        }

        internal Heuristic Create(HeuristicModel model)
        {
            return new Heuristic()
            {
                Id = model.Id,
                HeuristicTitle = model.HeuristicTitle,
                HeuristicText = model.HeuristicText
            };
        }

        internal UserGroup Create(GroupModel model)
        {
            return new UserGroup()
            {
                Id = model.Id,
                GroupName = model.GroupName
            };
        }

        public UserGroup CreateGroupWithUsers(GroupModel model, Infrastructure.Database.AppContext context)
        {
            var users = new Repository<UserGroup>(context).Get(model.Id);
            return new UserGroup()
            {
                Id = model.Id,
                GroupName = model.GroupName,
                Users = users.Users
            };
        }
    }
}