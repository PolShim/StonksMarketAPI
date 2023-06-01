using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.Request
{
    public class StockDataRequest
    {
        public string Function { get; set; }
        public string Symbol { get; set; }
        public string OutputSize { get; set; }
        public string Name { get; set; }
    }
}
