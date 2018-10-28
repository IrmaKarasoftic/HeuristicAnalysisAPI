namespace HeuristicAnalysis.API.Models
{
    public class AssignUserModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public bool Assign { get; set; }
    }
}
