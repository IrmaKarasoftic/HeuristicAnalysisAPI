namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class Odgovor
    {
        public int Id { get; set; }
        public string OpisProblema { get; set; }
        public NivoProblema NivoProblema { get; set; }
        public string LokacijaProblema { get; set; }
        public string PreporukaZaPoboljsanje { get; set; }
    }

    public enum NivoProblema { Nizak, Srednji, Visok }
}
