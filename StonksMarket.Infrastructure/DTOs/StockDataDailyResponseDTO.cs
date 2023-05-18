using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.DTOs
{
    public partial class StockDataDailyResponseDTO
    {
        [JsonProperty("Meta Data")]
        public StockDataMetaData MetaData { get; set; }

        [JsonProperty("Time Series (Daily)")]
        public Dictionary<DateTime, StockDataSampleDTO> TimeData { get; set; }
    }
}
