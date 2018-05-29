namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool Admin { get; set; }
    }
}
