using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

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
                Repository.Insert(Parser.Create(model, Repository.HomeContext()));
                return Ok();
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