namespace Api.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Genres { get; set; }
        public ICollection<string> GenresCollection => Genres.Split(',');
    }
}
