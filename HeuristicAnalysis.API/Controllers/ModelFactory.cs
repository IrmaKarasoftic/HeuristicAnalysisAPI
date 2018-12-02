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

        internal CompleteAnalysisDetails CreateAnalysisApplicationFormModel(AnalysisApplicationForm analysisApplicationForm)
        {
            return new CompleteAnalysisDetails()
            {
                AnalysisId = analysisApplicationForm.Id,
                Heuristics = analysisApplicationForm.Heuristics.Select(CreateHeursiHeuristicModel).ToList(),
                Groups = analysisApplicationForm.Groups.Select(CreateGroupModel).ToList()
            };
        }

        private HeuristicModel CreateHeursiHeuristicModel(Heuristic heuristics)
        {
            return new HeuristicModel()
            {
                Id = heuristics.Id,
                HeuristicText = heuristics.HeuristicText,
                HeuristicTitle = heuristics.HeuristicTitle
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

        public AnalysisModel CreateAnalysisModel(AnalysisApplicationForm analiza, AppContext context)
        {
            var vers = context.Versions.SingleOrDefault(v => v.AnalysisApplicationForm.Id == analiza.Id);
            var version = Create(vers);
            var app = Create(context.Applications.SingleOrDefault(a => a.Versions.Select(ver=> ver.Id).Contains(vers.Id)));
            return new AnalysisModel()
            {
                Id = vers.AnalysisApplicationForm.Id,
                Verzija = version,
                Aplikacija = app
            };
        }

        public AnalysisModel CreateAnalysisModel(Analysis analiza, AppContext context)
        {
            var version = Create(context.Versions.SingleOrDefault(v => v.AnalysisApplicationForm.Id == analiza.Id));
            var app = Create(context.Applications.SingleOrDefault(a => a.Id == version.Id));
            return new AnalysisModel()
            {
                Verzija = version,
                Aplikacija = app
            };
        }

        public QuestionModel Create(QuestionAnswer pitanje, AppContext context)
        {
            return new QuestionModel()
            {
                Id = pitanje.Id,
                Heuristic = pitanje.Heuristic,
                Description = pitanje.Description
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