using System;

namespace Data.Entities
{
    public class Activity
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}