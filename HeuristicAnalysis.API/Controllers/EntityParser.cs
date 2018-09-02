using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class EntityParser
    {
        public Analysis Create(AnalysisModel model, AppContext context)
        {
            return new Analysis()
            {
                Id = model.Id,
                ApplicationId = model.Aplikacija.Id,
                QuestionId = model.Pitanje.Id,
                ReviewerId = model.Korisnik.Id,
                VersionId = model.Verzija.Id
            };
        }

        public Application Create(ApplicationModel model, AppContext context)
        {
            return new Application()
            {
                Id = model.Id,
                Name = model.Name,
                Url = model.Url
            };
        }

        public Version Create(VersionModel verzija, AppContext homeContext)
        {
            return new Version()
            {
                Id = verzija.Id,
                Date = verzija.Date,
                VersionName = verzija.VersionName
            };
        }

        public Question Create(QuestionModel pitanje, AppContext context)
        {
            return new Question()
            {
                Id = pitanje.Id,
                Heuristic = pitanje.Heuristic
            };
        }

        public User Create(UserModel korisnik, AppContext context)
        {
            return new User()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName
            };
        }

        public UserGroup Create(UserGroupModel grupa, AppContext context)
        {
            return new UserGroup()
            {
                Id = grupa.Id,
                GroupName = grupa.GroupName,
                //Korisnici
            };
        }

        public User Create(User korisnik, AppContext homeContext)
        {
            return new User()
            {
                Id = korisnik.Id,
                Admin = korisnik.Admin,
                FirstName = korisnik.FirstName,
                LastName = korisnik.LastName
            };
        }
    }
}