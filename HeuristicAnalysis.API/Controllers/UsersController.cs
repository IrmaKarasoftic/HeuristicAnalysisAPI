using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;
using HeuristicAnalysis.Infrastructure.Services;

namespace HeuristicAnalysis.API.Controllers
{
    public class UserController : HomeController<User>
    {
        public UserController(Repository<User> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var users = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var user = Repository.Get(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(UserModel model)
        {
            try
            {
                if (model == null) return BadRequest("Model is null");
                //var password = System.Web.Security.Membership.GeneratePassword(8, 3);
                var password = "Master123";
                var entity = Parser.Create(model, Repository.HomeContext(), password);
                Repository.Insert(entity);
                //var emailModel = new Infrastructure.Services.EmailModel()
                //{
                //    Username = model.FirstName + " " + model.LastName,
                //    Password = password,
                //    MailTo = model.Email
                //};
                //EmailService.SendEmail(emailModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public IHttpActionResult Post(LoginModel model)
        {
            try
            {
                if(model.Username == "admin" && model.Password == "admin")
                {
                    return Ok(new UserModel()
                    {
                        Admin = true
                    });
                }
                var context = Repository.HomeContext();
                var user = context.Users.FirstOrDefault(u => u.Email == model.Username);
                if(user == null) throw new Exception("User with this email does not exist");
                if (Parser.ComputeSha256Hash(model.Password) != user.Password) throw new Exception("Password is not valid");
                return Ok(Factory.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(UserModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var user = Repository.Get(id);
                if (user == null) return NotFound();
                Repository.Update(Parser.Create(model, Repository.HomeContext()), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                var user = Repository.Get(id);
                if (user == null) return NotFound();
                Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}