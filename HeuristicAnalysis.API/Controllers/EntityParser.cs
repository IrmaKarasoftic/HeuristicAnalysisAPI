using System;
using System.Collections.Generic;
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



        public QuestionAnswer Create(QuestionModel pitanje, Infrastructure.Database.AppContext context)
        {
            return new QuestionAnswer()
            {
                Id = pitanje.Id,
                Heuristic = pitanje.Heuristic
            };
        }

        internal QuestionAnswer Create(CreateFilledInHeuristicModel heuristic)
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
            var qa = new QuestionAnswer
            {
                Id = heuristic.Id,
                Heuristic = heuristic.HeuristicText,
                Description = heuristic.Description,
                Location = heuristic.Location,
                Recommendation = heuristic.Recommendation,
                Level = heuristic.Level,
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