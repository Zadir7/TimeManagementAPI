using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        internal DbSet<User> Users { get; set; }
        internal DbSet<Activity> Activities { get; set; }
    }
}