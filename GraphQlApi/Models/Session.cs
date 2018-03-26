namespace GraphQlApi.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Speaker Speaker { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}