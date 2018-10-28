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
            var a =
                new ApplicationModel()
                {
                    Id = aplikacija.Id,
                    Name = aplikacija.Name,
                    Url = aplikacija.Url,
                    Versions = aplikacija.Versions.Select(Create).ToList()
                };
            return new ApplicationModel()
            {
                Id = aplikacija.Id,
                Name = aplikacija.Name,
                Url = aplikacija.Url,
                Versions = aplikacija.Versions.Select(Create).ToList()
            };

            VersionModel Create(Version x)
            {
                return new VersionModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    VersionName = x.VersionName
                };
            }
        }

        internal HeuristicModel Create(Heuristic x)
        {
            return new HeuristicModel()
            {
                Id = x.Id,
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

        public GroupModel Create(Group grupa, AppContext context)
        {
            return new GroupModel()
            {
                Id = grupa.Id,
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
    }

}