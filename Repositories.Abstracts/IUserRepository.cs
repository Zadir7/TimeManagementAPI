using System.Collections.Generic;
using Data.Entities;

namespace Repositories.Abstracts
{
    public interface IUserRepository : ICrudRepository<User>
    {
        public IEnumerable<User> GetUserList();
    }
}