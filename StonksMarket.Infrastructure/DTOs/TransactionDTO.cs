using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.DTOs
{
    public class TransactionDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string StockSymbol { get; set; } = null!;

        public long Quantity { get; set; }

        public decimal Value { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
