using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.DTOs
{
    public class UserStockDTO
    {
        public int Id { get; set; }

        public string StockSymbol { get; set; } = null!;

        public long Quantity { get; set; }

        public int UserId { get; set; }

        public double Price { get; set; }
    }
}
