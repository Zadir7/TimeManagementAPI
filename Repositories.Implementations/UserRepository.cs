using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repositories.Abstracts;

namespace Repositories.Implementations
{
    public class UserRepository : DbSetRepository<User>, IUserRepository
    {
        protected override DbSet<User> DbSet { get; init; }
        public UserRepository(ApplicationContext context) : base(context)
        {
            DbSet = new InternalDbSet<User>(context, nameof(User));
        }

        public IEnumerable<User> GetUserList() => DbSet;

        public User GetByEmail(string email) => _context.Users.FirstOrDefault(u => u.Email == email);
        
    }
}