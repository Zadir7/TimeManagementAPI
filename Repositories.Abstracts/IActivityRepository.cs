using System.Collections.Generic;
using Data.Entities;

namespace Repositories.Abstracts
{
    public interface IActivityRepository : ICrudRepository<Activity>
    {
        public IEnumerable<Activity> GetActivitiesOfUserOnChosenMonth(User user, int month);
    }
}