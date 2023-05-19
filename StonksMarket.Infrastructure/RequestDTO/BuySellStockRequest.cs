using StonksMarket.Core.StonksDbModels;
using StonksMarket.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Request
{
    public class BuySellStockRequest
    {
        public UserStockDTO UserStock { get; set; }
        public string UserName { get; set; }
    }
}
