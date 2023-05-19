using StonksMarket.Core.StonksDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Core.Repository
{
    public interface IUserStockRepository : IRepositoryBase<UserStock>
    {
        Task<List<UserStock>> GetUserStocksByUserName(string userName);
    }
}
