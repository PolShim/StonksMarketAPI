using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.DTOs
{
    public class StockDataSampleDTO
    {
        [JsonProperty("1. open")]
        public string Open { get; set; }

        [JsonProperty("2. high")]
        public string High { get; set; }

        [JsonProperty("3. low")]
        public string Low { get; set; }

        [JsonProperty("4. close")]
        public string Close { get; set; }

        [JsonProperty("5. adjusted close")]
        public string The5AdjustedClose { get; set; }

        [JsonProperty("6. volume")]
        public long Volume { get; set; }

        [JsonProperty("7. dividend amount")]
        public string DividendAmount { get; set; }

        [JsonProperty("8. split coefficient")]
        public string SplitCoefficient { get; set; }
    }
}
