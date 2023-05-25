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
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(StonksDbContext context) : base(context)
        {
        }

        public async Task<List<Transaction>> GetTransactionsByUser(string userName)
        {
            return await _context.Transactions.Where(x => x.User.Name == userName).ToListAsync();
        }

        public async Task DeleteTransactionsByUser(string userName)
        {
            var transactionsToDelete = await this.GetTransactionsByUser(userName);
            _context.Transactions.RemoveRange(transactionsToDelete);

            await _context.SaveChangesAsync();

            return;
        }
    }
}
