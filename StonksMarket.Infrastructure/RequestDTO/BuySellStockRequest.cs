using StonksMarket.Core.StonksDbModels;
using StonksMarket.Infrastructure.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Request
{
    public class BuySellStockRequest
    {
        public UserStockBuySellDTO UserStock { get; set; }
        public string UserName { get; set; }
    }
}
