﻿namespace HeuristicAnalysis.API.Models
{
    public class UserWithAssignedFlag
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public bool Admin { get; set; }
        public bool Assigned { get; set; }
    }
}
