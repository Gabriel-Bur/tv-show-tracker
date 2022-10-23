namespace Api.DTOs.Response.Show
{
    public class ShowResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<string> Genres { get; set; }
    }
}
