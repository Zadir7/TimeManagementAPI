using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<User> GetUserList() => DbSet;

        public User GetByEmail(string email) => DbSet.FirstOrDefault(u => u.Email == email);
    }
}