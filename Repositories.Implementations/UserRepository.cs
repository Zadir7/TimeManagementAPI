using System.Collections.Generic;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;

namespace Repositories.Implementations
{
    public class UserRepository : DbSetRepository<User>, IUserRepository
    {
        public UserRepository(DbSet<User> dbSet, DbContext context) : base(dbSet, context)
        {
        }

        public IEnumerable<User> GetUserList()
        {
            return DbSet;
        }
    }
}