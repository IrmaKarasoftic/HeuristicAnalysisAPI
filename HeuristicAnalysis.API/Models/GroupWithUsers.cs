using HeuristicAnalysis.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeuristicAnalysis.API.Models
{
    public class GroupWithUsers
    {
        public int GroupId;
        public List<UserWithAssignedFlag> Users;
    }
}