using System;
using System.Linq;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class GroupsController : HomeController<Group>
    {
        public GroupsController(Repository<Group> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var groups = Repository.Get().ToList().Select(x => Factory.Create(x, Repository.HomeContext())).ToList();
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
        [Route("api/Groups/users/{id:int}")]
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
        [Route("api/Groups/assign")]
        public IHttpActionResult Assign(AssignUserModel model)
        {
            try
            {
                var userGroupRepo = new Repository<UserGroup>(Repository.HomeContext());
                if (model.Assign)
                {
                    var userGroup = new UserGroup()
                    {
                        GroupId = model.GroupId,
                        UserId = model.UserId
                    };
                    userGroupRepo.Insert(userGroup);
                }
                else
                {
                    var ugToDelete = userGroupRepo.Get().FirstOrDefault(ug => ug.UserId == model.UserId && ug.GroupId == model.GroupId);
                    if (ugToDelete != null) userGroupRepo.Delete(ugToDelete.Id);
                }
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
                Repository.Update(Parser.Create(model, Repository.HomeContext()), id);
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