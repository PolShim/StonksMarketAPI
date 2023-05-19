using Microsoft.AspNetCore.Mvc;
using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.Request;
using StonksMarket.Infrastructure.Services;

namespace StonksMarketAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockDataController : ControllerBase
    {

        private readonly ILogger<StockDataController> _logger;
        private readonly IStockPricesDataService _stockPricesDataService;

        public StockDataController(ILogger<StockDataController> logger, IStockPricesDataService stockPricesDataService)
        {
            _logger = logger;
            _stockPricesDataService = stockPricesDataService;
        }

        [HttpGet("GetStockDataDaily")]
        public async Task<StockDataDailyResponseDTO> GetStockDataDaily([FromQuery]StockDataRequest request)
        {
            return await _stockPricesDataService.GetStockDataDaily(request);
        }
    }
}