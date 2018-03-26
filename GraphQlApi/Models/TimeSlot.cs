using System;

namespace GraphQlApi.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Room Room { get; set; }
    }
}