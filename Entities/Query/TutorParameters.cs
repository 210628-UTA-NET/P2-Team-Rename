namespace Entities.Query {
    public class TutorParameters: PagedQueryParameters {
        public string Name { get; set; }
        public decimal? HourlyRate { get; set; }
        public string Topic { get; set; }
        public double? Rating { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Distance { get; set; }
    }
}