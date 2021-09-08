using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repositories.Abstracts;

namespace Repositories.Implementations
{
    public class ActivityRepository : DbSetRepository<Activity>, IActivityRepository
    {
        protected override DbSet<Activity> DbSet { get; init; }
        public ActivityRepository(ApplicationContext context) : base(context)
        {
            DbSet = new InternalDbSet<Activity>(context, nameof(Activity));
        }

        public IEnumerable<Activity> GetActivitiesOfUserOnChosenMonth(Guid userId, int month)
        {
            return _context.Activities.Where(activity => 
                activity.User.Id == userId && 
                activity.Date.Year == DateTime.Now.Year &&
                activity.Date.Month == month);
        }

        
    }
}