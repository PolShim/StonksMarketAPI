using Microsoft.AspNetCore.Mvc;
using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.Request;

namespace StonksMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserStockController : ControllerBase
    {
        [HttpGet("GetStockDataDaily")]
        public void GetStockDataDaily([FromQuery] StockDataRequest request)
        {
            return;
        }
    }
}
