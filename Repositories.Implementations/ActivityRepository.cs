using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;

namespace Repositories.Implementations
{
    public class ActivityRepository : DbSetRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(DbSet<Activity> dbSet, DbContext context) : base(dbSet, context)
        {
        }

        public IEnumerable<Activity> GetActivitiesOfUserOnChosenMonth(User user, int month)
        {
            return DbSet.Where(activity => 
                activity.User == user && 
                activity.Date.Year == DateTime.Now.Year &&
                activity.Date.Month == month);
        }
    }
}