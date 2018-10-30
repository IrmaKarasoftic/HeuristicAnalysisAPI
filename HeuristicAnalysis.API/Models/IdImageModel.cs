using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeuristicAnalysis.API.Models
{
    public class IdImageModel
    {
        public int Id { get; set; }
        public List<string> Images { get; set; }
    }
}