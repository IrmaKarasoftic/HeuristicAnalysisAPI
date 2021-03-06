﻿using System;
using System.Collections.Generic;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Occupation { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Admin { get; set; }
        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
