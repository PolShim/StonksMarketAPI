using Microsoft.EntityFrameworkCore;
using StonksMarket.Core.Repository;
using StonksMarket.Core.StonksDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Repository
{
    public class UserStockRepository : RepositoryBase<UserStock>, IUserStockRepository
    {
        public UserStockRepository(StonksDbContext context) : base(context)
        {
        }

        public async Task<List<UserStock>> GetUserStocksByUserName( string userName)
        {
            return await _context.UserStocks.Where(x => x.User.Name == userName).ToListAsync();
        }
    }
}
