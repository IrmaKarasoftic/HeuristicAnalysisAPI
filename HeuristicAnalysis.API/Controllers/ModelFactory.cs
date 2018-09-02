using System;
using System.Linq;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using AppContext = HeuristicAnalysis.Infrastructure.Database.AppContext;

namespace HeuristicAnalysis.API.Controllers
{
    public class ModelFactory
    {
        public ApplicationModel Create(Application aplikacija, AppContext context)
        {
            return new ApplicationModel()
            {
                Id = aplikacija.Id,
                Name = aplikacija.Name,
                Url = aplikacija.Url,
                //Verzije = new Repository<Verzija>(context).Get().ToList().Select(verzija => Create(verzija, context)).ToList()
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
                Pitanje = Create(new Repository<Question>(context).Get(analiza.QuestionId), context)
            };
        }

        public QuestionModel Create(Question pitanje, AppContext context)
        {
            return new QuestionModel()
            {
                Id = pitanje.Id,
                Heuristic = pitanje.Heuristic,
            };
        }


        public UserModel Create(User korisnik, AppContext context)
        {
            return new UserModel()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName
            };
        }

        public UserGroupModel Create(UserGroup grupa, AppContext context)
        {
            return new UserGroupModel()
            {
                Id = grupa.Id,
                GroupName = grupa.GroupName,
                // Korisnici = grupa.Korisnici.ToList().Select(x => Create(x, context)).ToList();
            };
        }
    }
}