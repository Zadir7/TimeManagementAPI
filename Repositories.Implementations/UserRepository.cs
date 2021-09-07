using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstracts;

namespace Repositories.Implementations
{
    public class UserRepository : DbSetRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public IEnumerable<User> GetUserList() => DbSet;

        public User GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);
    }
}