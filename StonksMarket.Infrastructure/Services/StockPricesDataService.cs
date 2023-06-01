using Newtonsoft.Json;
using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StonksMarket.Infrastructure.Services
{
    public class StockPricesDataService : IStockPricesDataService
    {
        public async Task<StockDataDailyResponseDTO> GetStockDataDaily(StockDataRequest request)
        {
            // Define the request URI and parameters
            var url = "https://www.alphavantage.co/query";

            // Create a new HttpClient instance
            using var client = new HttpClient();

            // Add the query parameters to the request URI
            var uriBuilder = new UriBuilder(url);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

            query["apikey"] = "2TOUOONF3KUYYVE3";
            query["outputsize"] = request.OutputSize;
            query["symbol"] = request.Symbol;
            query["function"] = request.Function;

            uriBuilder.Query = query.ToString();
            var requestUri = uriBuilder.ToString();

            // Make the HTTP GET request and deserialize the JSON response
            var response = await client.GetAsync(requestUri);
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<StockDataDailyResponseDTO>(jsonString);

            // Access the data returned by the API
            Console.WriteLine(data);
            data.MetaData.Name = request.Name;
            return data;
        }
    }
}
