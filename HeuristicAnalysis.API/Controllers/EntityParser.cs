using System;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using Version = HeuristicAnalysis.Infrastructure.Database.Entities.Version;

namespace HeuristicAnalysis.API.Controllers
{
    public class EntityParser
    {
        public Analysis Create(AnalysisModel model, Infrastructure.Database.AppContext context)
        {
            return new Analysis()
            {
                Id = model.Id,
                ApplicationId = model.Aplikacija.Id,
                ReviewerId = model.Korisnik.Id,
                VersionId = model.Verzija.Id
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
                VersionName = verzija.VersionName
            };
        }

        public QuestionAnswer Create(QuestionModel pitanje, Infrastructure.Database.AppContext context)
        {
            return new QuestionAnswer()
            {
                Id = pitanje.Id,
                Heuristic = pitanje.Heuristic
            };
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

        public Group Create(GroupModel grupa, Infrastructure.Database.AppContext context)
        {
            return new Group()
            {
                Id = grupa.Id,
                GroupName = grupa.GroupName,
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
    }
}