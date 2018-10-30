using System;

namespace HeuristicAnalysis.Infrastructure.Database.Entities
{
    public class UploadedImage
    {
        public int Id { get; set; }
        public int AnalysisId { get; set; }
        public string Img { get; set; }
    }
}
