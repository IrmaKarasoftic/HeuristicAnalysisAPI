namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Pitanje
    {
        public int Id { get; set; }
        public string TekstPitanja { get; set; }
        public Odgovor Odgovor { get; set; }
    }
}
