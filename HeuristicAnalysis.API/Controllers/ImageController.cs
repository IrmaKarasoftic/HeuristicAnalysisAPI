using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using HeuristicAnalysis.API.Models;
using HeuristicAnalysis.Infrastructure.Database;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Controllers
{
    public class ImageController : HomeController<UploadedImage>
    {
        public ImageController(Repository<UploadedImage> repo) : base(repo)
        {
        }

        [HttpPost]
        public IHttpActionResult Upload(IdImageModel model)
        {
            try
            {

                foreach (var image in model.Images)
                {
                    var img = new UploadedImage() {Id = 0, AnalysisId = model.Id, Img = image};
                    Repository.Insert(img);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}