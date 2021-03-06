﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class HeuristicsController : HomeController<Heuristic>
    {
        public HeuristicsController(Repository<Heuristic> repo) : base(repo) { }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            { 

                var a = Repository.Get().ToList();
                var questions = Repository.Get().Where(x => x.Id > 10).ToList().Select(x => Factory.CreateCheckedHeuristicModel(x)).ToList();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/Heuristics/nielsen")]
        public IHttpActionResult GetNielsen()
        {
            try
            {
                var questions = Repository.Get().Where(x => x.Id <= 10).ToList().Select(x => Factory.CreateCheckedHeuristicModel(x)).ToList(); ;
                return Ok(questions);
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
                var question = Repository.Get(id);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(HeuristicModel model)
        {
            try
            {
                if (model == null) return BadRequest("Model is null");
                Repository.Insert(Parser.Create(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(HeuristicModel model, int id)
        {
            if (model == null) return BadRequest("Model is null");
            if (id <= 0) return BadRequest("ID not valid");
            try
            {
                var heuristic = Repository.Get(id);
                if (heuristic == null) return NotFound();
                Repository.Update(Parser.Create(model), id);
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
                var heuristic = Repository.Get(id);
                if (heuristic == null) return NotFound();
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