using StonksMarket.Core.StonksDbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Core.Repository
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        Task<List<Transaction>> GetTransactionsByUser(string userName);
        Task DeleteTransactionsByUser(string userName);
    }
}
