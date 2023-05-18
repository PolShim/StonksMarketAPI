using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.Request;

namespace StonksMarket.Infrastructure.Services
{
    public interface IStockPricesDataService
    {
        Task<StockDataDailyResponseDTO> GetStockDataDaily(StockDataRequest request);
    }
}