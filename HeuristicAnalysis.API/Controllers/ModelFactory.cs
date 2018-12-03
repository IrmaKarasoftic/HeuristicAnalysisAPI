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
    public class ModelFactory
    {
        public ApplicationModel Create(Application aplikacija)
        {
            var app = new ApplicationModel
            {
                Id = aplikacija.Id,
                Name = aplikacija.Name,
                Url = aplikacija.Url,
                Versions = aplikacija.Versions.Select(v => Create(v, aplikacija)).ToList()
            };
            return app;
        }
        public ApplicationModel CreateWithoutVersion(Application aplikacija)
        {
            var app = new ApplicationModel
            {
                Id = aplikacija.Id,
                Name = aplikacija.Name,
                Url = aplikacija.Url,
            };
            return app;
        }

        private static VersionModel Create(Version v, Application app)
        {
            return new VersionModel()
            {
                Id = v.Id,
                VersionName = v.VersionName,
                Date = v.Date,
                ApplicationId = app.Id,
                AnalysisId = v.AnalysisApplicationForm?.Id ?? 0
            };
        }

        private static VersionModel Create(Version v)
        {
            return new VersionModel()
            {
                Id = v.Id,
                VersionName = v.VersionName,
                Date = v.Date
            };
        }

        internal CompleteAnalysisDetails CreateAnalysisApplicationFormModel(Analysis analysis)
        {
            return new CompleteAnalysisDetails()
            {
                AnalysisId = analysis.Id,
                Heuristics = analysis.QuestionsAndAnswers.Select(CreateHeuristicModelWithAnswers).ToList(),
            };
        }

        private QuestionModel CreateHeuristicModelWithAnswers(AnsweredQuestion qa)
        {
            var hwa = new QuestionModel()
            {
                Id = qa.Id,
                HeuristicText = qa.HeuristicText,
                HeuristicTitle = qa.HeuristicTitle,
                Answers = qa.Answers.Select(Create).ToList()
            };
            return hwa;
        }

        private static ImageSrc Create(HeuristicImage i)
        {
            return new ImageSrc()
            {
                Src = i.Img
            };
        }
        private static AnswerModel Create(Answer answer)
        {
            return new AnswerModel()
            {
                Id = answer.Id,
                Description = answer.Description,
                Location = answer.Location,
                Recommendation = answer.Recommendation,
                Level = answer.Level,
                Images = answer.Images.Select(Create).ToList(),
            };
        }

        internal GroupModel CreateWithCheckedFalse(UserGroup x, AppContext appContext)
        {
            return new GroupModel()
            {
                Id = x.Id,
                GroupName = x.GroupName,
                Checked = false,
                NumberOfUsers = x.Users.Count
            };
        }
        internal GroupModel CreateGroupModel(UserGroup x)
        {
            return new GroupModel()
            {
                Id = x.Id,
                GroupName = x.GroupName,
                Checked = false,
                NumberOfUsers = x.Users.Count
            };
        }

        internal HeuristicModel Create(Heuristic x)
        {
            return new HeuristicModel()
            {
                Id = x.Id,
                HeuristicTitle = x.HeuristicTitle,
                HeuristicText = x.HeuristicText
            };
        }

        internal CheckedHeuristicModel CreateCheckedHeuristicModel(Heuristic x)
        {
            return new CheckedHeuristicModel()
            {
                Id = x.Id,
                Checked = false,
                HeuristicTitle = x.HeuristicTitle,
                HeuristicText = x.HeuristicText
            };
        }
        public VersionModel Create(Infrastructure.Database.Entities.Version verzija, AppContext homeContext)
        {
            return new VersionModel()
            {
                Id = verzija.Id,
                Date = verzija.Date,
                VersionName = verzija.VersionName
            };
        }

        public AnalysisModel CreateAnalysisModel(AnalysisApplicationForm analiza, AppContext context, User user)
        {
            var vers = context.Versions.SingleOrDefault(v => v.AnalysisApplicationForm.Id == analiza.Id);
            var version = Create(vers);
            var app = Create(context.Applications.SingleOrDefault(a => a.Versions.Select(ver=> ver.Id).Contains(vers.Id)));
            var created = context.Analyses.Any(a => a.Reviewer.Id == user.Id && a.Version.Id == version.Id);
            return new AnalysisModel()
            {
                Id = analiza.Id,
                Verzija = version,
                Aplikacija = app,
                Created = created,
                AnalysisFormId = vers.AnalysisApplicationForm.Id,
                Korisnik = Create(user)
            };
        }

        public UserModel Create(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Admin = user.Admin,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Occupation = user.Occupation,
                DateOfBirth = user.DateOfBirth.ToShortDateString(),
                Name = user.FirstName + " " + user.LastName
            };
        }

        public AnalysisModel CreateAnalysisModel(Analysis analiza, AppContext context)
        {
            var version = Create(context.Versions.SingleOrDefault(v => v.AnalysisApplicationForm.Id == analiza.Id));
            var app = CreateWithoutVersion(context.Applications.SingleOrDefault(a => a.Id == version.Id));
            return new AnalysisModel()
            {
                Id = analiza.Id,
                Verzija = version,
                Aplikacija = app
            };
        }

        public QuestionModel Create(AnsweredQuestion question, AppContext context)
        {
            return new QuestionModel()
            {
                Id = question.Id,
                HeuristicTitle = question.HeuristicTitle,
                HeuristicText = question.HeuristicText,
            };
        }


        public UserModel Create(User korisnik, AppContext context)
        {
            return new UserModel()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName,
                Email = korisnik.Email,
                Name = korisnik.LastName + " " + korisnik.FirstName,
                Occupation = korisnik.Occupation,
                DateOfBirth = korisnik.DateOfBirth.ToShortDateString()
            };
        }

        public GroupWithUsers CreateGroupWithUsersModel(int id, AppContext context)
        {
            var userGroup = new Repository<UserGroup>(context).Get().FirstOrDefault(ug => ug.Id == id);
            var allUsers = new Repository<User>(context).Get().ToList();

            var groupWithUsers = new GroupWithUsers
            {
                GroupId = id,
                Users = allUsers.Select(u => Create(u, userGroup)).ToList()
            };
            return groupWithUsers;
        }

        private static UserWithAssignedFlag Create(User u, UserGroup userGroup)
        {
            var assigned = userGroup.Users.Select(user => user.Id).Contains(u.Id);
            return new UserWithAssignedFlag()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Name = u.FirstName + ' ' + u.LastName,
                Assigned = assigned,
                DateOfBirth = u.DateOfBirth.ToShortDateString(),
                Occupation = u.Occupation,
                Admin = u.Admin
            };
        }

        private HeuristicModel CreateHeuristicWithImagesModel(Heuristic heuristic)
        {
            return new HeuristicModel()
            {
                Id = heuristic.Id,
                HeuristicText = heuristic.HeuristicText,
                HeuristicTitle = heuristic.HeuristicTitle,
                Images = new List<HeuristicImage>()
            };
        }

    }

}