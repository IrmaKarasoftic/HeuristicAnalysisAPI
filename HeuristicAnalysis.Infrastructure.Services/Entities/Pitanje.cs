﻿namespace HeuristicAnalysis.Infrastructure.Services.Entities
{
    internal class Pitanje
    {
        public int Id { get; set; }
        public string TekstPitanja { get;set }
        public Odgovor Odgovor { get; set; }
    }
}
