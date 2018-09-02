using System;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Admin { get; set; }
    }
}
