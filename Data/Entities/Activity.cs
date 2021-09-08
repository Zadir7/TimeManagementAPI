using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public User User { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}