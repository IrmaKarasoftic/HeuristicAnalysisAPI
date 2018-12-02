using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class UserGroupsController : HomeController<UserGroup>
    {
        public UserGroupsController(Repository<UserGroup> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var groups = Repository.Get().ToList().Select(x => Factory.CreateWithCheckedFalse(x, Repository.HomeContext())).ToList();
                return Ok(groups);
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
                var group = Repository.Get(id);
                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/UserGroups/users/{id:int}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var users = Factory.CreateGroupWithUsersModel(id, Repository.HomeContext());
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/UserGroups/assign")]
        public IHttpActionResult Assign(AssignUserModel model)
        {
            try
            {
                var context = Repository.HomeContext();
                var userGroup = Repository.Get(model.GroupId);
                var user = new Repository<User>(context).Get(model.UserId);
                if (model.Assign)
                    userGroup.Users.Add(user);
                else
                    userGroup.Users.Remove(user);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(GroupModel model)
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
        public IHttpActionResult Put(GroupModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var group = Repository.Get(id);
                if (group == null) return NotFound();
              //  Repository.Update(Parser.Create(model, Repository.HomeContext()), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var group = Repository.Get(id);
                if (group == null) return NotFound();
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