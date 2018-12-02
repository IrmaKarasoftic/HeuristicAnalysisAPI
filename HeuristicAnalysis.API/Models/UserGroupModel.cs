using System.Collections.Generic;
using System.Collections.ObjectModel;
using HeuristicAnalysis.Infrastructure.Database.Entities;

namespace HeuristicAnalysis.API.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool Checked { get; set; }
        public int NumberOfUsers { get; set; }
    }
}
