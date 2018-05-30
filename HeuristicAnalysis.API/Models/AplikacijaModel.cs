using System.Collections.Generic;

namespace HeuristicAnalysis.API.Models
{
    public class AplikacijaModel
    {
        public AplikacijaModel()
        {
            Verzije = new List<VerzijaModel>();
        }
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Url { get; set; }
        public List<VerzijaModel> Verzije { get; set; }
    }
}
