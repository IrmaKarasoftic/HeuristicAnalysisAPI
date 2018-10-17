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
                Occupation = korisnik.Occupation,
                DateOfBirth = korisnik.DateOfBirth.ToShortDateString()
            };
        }

        public UserGroupModel Create(UserGroup grupa, AppContext context)
        {
            return new UserGroupModel()
            {
                Id = grupa.Id,
                GroupName = grupa.GroupName,
                NumberOfUsers = 5
                // Korisnici = grupa.Korisnici.ToList().Select(x => Create(x, context)).ToList();
            };
        }
    }
}