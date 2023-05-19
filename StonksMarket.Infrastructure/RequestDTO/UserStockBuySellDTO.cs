using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.RequestDTO
{
    public class UserStockBuySellDTO
    {
        public string StockSymbol { get; set; } = null!;

        public long Quantity { get; set; }

        public double Price { get; set; }
    }
}
