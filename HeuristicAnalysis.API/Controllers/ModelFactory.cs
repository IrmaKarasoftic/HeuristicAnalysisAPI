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
        public ApplicationModel Create(Application aplikacija, AppContext context)
        {
            var app = new ApplicationModel
            {
                Id = aplikacija.Id,
                Name = aplikacija.Name,
                Url = aplikacija.Url,
                Versions = aplikacija.Versions.Select(x => CreateAppVersionModel(x, aplikacija.Id, context)).ToList(),
            };
            return app;
        }

        private static VersionModel CreateAppVersionModel(Version x, int id, AppContext context)
        {
            var analysis = context.AnalysesApplication.FirstOrDefault(v => v.ApplicationId == id && v.VersionId == x.Id);
            return new VersionModel()
            {
                Id = x.Id,
                Date = x.Date,
                VersionName = x.VersionName,
                AnalysisId = analysis?.Id ?? 0
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


        public AnalysisModel Create(Analysis analiza, AppContext context)
        {
            return new AnalysisModel()
            {
                Id = analiza.Id,
                Aplikacija = Create(new Repository<Application>(context).Get(analiza.ApplicationId), context),
                Korisnik = Create(new Repository<User>(context).Get(analiza.ReviewerId), context),
                Verzija = Create(new Repository<Infrastructure.Database.Entities.Version>(context).Get(analiza.VersionId), context),
            };
        }

        public AnalysisModel CreateAnalysisModel(AnalysisApplication analiza, int versionId, AppContext context)
        {
            var app = Create(context.Applications.Find(analiza.ApplicationId), context);
            var version = Create(context.Versions.Find(versionId), context);
            return new AnalysisModel()
            {
                Id = analiza.Id,
                Aplikacija = app,
                Verzija = version
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

        public GroupModel CreateWithCheckedFalse(Group grupa, AppContext context)
        {
            return new GroupModel()
            {
                Id = grupa.Id,
                Checked = false,
                GroupName = grupa.GroupName,
                NumberOfUsers = 5
            };
        }

        public GroupWithUsers CreateGroupWithUsersModel(int id, AppContext context)
        {
            var group = new Repository<Group>(context).Get(id);
            var userGroups = new Repository<UserGroup>(context).Get().ToList();
            var allUsers = new Repository<User>(context).Get().ToList();
            var userList = new List<UserWithAssignedFlag>();
            foreach (var user in allUsers)
            {
                var userModel = new UserWithAssignedFlag()
                {
                    Id = user.Id,
                    DateOfBirth = user.DateOfBirth.ToShortTimeString(),
                    Admin = user.Admin,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Name = user.LastName + " " + user.FirstName,
                    Occupation = user.Occupation,
                    Assigned = false
                };
                userModel.Assigned = userGroups.Any(g => g.GroupId == group.Id && user.Id == g.UserId);
                userList.Add(userModel);
            }
            var groupWithUsers = new GroupWithUsers
            {
                GroupId = id,
                Users = userList
            };
            return groupWithUsers;
        }

        public CompleteAnalysisDetails CreateCompleteAnalysisDetailsModel(int analisysId, AppContext context)
        {
            var analisys = context.AnalysesApplication.Find(analisysId);
            //var groups = new List<string>();
            var heuristics = new List<Heuristic>();
            var groupEntitiess = context.AnalysesGroups.Where(g => g.AnalysisId == analisys.Id)
                .ToList();
            var heuristicEntities = context.AnalysesHeuristics.Where(h => h.AnalysisId == analisys.Id).ToList();
            var version = context.Versions.FirstOrDefault(h => h.Id == analisys.VersionId);
            var a = context.Groups.ToList();
            var b = a.FirstOrDefault(g => g.Id == groupEntitiess[0].Id);
            //foreach (var analysesGroups in groupEntitiess) groups.Add(context.Groups.FirstOrDefault(g => g.Id == analysesGroups.Id).GroupName);
            foreach (var heuristic in heuristicEntities) heuristics.Add(context.Heuristics.FirstOrDefault(g => g.Id == heuristic.HeuristicId));
            var app = new Repository<Application>(context).Get(analisys.ApplicationId);

            var analysis = new CompleteAnalysisDetails()
            {
                ApplicationName = app.Name,
                VersionName = version.VersionName,
                //Groups = groups,
                Heuristics = heuristics
            };
            return analysis;
        }
    }

}