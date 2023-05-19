using Microsoft.EntityFrameworkCore;
using StonksMarket.Core;
using StonksMarket.Core.Repository;
using StonksMarket.Core.StonksDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(StonksDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByName(string username)
        {
            return await _context.Users.Where(x => x.Name == username).FirstOrDefaultAsync();
        }
    }
}
