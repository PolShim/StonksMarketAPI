using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StonksMarket.Core.Repository;
using StonksMarket.Core.StonksDbModels;
using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.Request;

namespace StonksMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserStockController : ControllerBase
    {
        private readonly IUserStockRepository _userStockRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public UserStockController(IUserStockRepository userStockRepository, IUserRepository userRepository, ITransactionRepository transactionRepository, IMapper mapper)
        {
            _userStockRepository = userStockRepository;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet("GetUserStockByUserName")]
        public async Task<List<UserStockDTO>> GetUserStockByUserName(string userName)
        {
            return _mapper.Map<List<UserStockDTO>>(await _userStockRepository.GetUserStocksByUserName(userName));
        }
        [HttpPost("BuyStockByUser")]
        public async Task<UserStockDTO> BuyStockByUser(BuySellStockRequest request)
        {
            var user = await _userRepository.GetUserByName(request.UserName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if ((float)user.AccountBalance < (request.UserStock.Quantity * request.UserStock.Price))
            {
                throw new Exception("Not enough money to buy");
            }

            var userStocks = await _userStockRepository.GetUserStocksByUserName(request.UserName);
            var existingStock = userStocks.Where(x => x.StockSymbol == request.UserStock.StockSymbol).FirstOrDefault();
            if (existingStock is not null)
            {
                existingStock.Quantity += request.UserStock.Quantity;
            }
            else
            {

                existingStock = await _userStockRepository.Add(_mapper.Map<UserStock>(request.UserStock));
                var cashToSubstract = request.UserStock.Quantity * request.UserStock.Price;
                user.AccountBalance = user.AccountBalance - (decimal)cashToSubstract;
                await _userRepository.Update(user);
            }


            Transaction transaction = new Transaction()
            {
                UserId = user.UserId,
                Quantity = request.UserStock.Quantity,
                StockSymbol = request.UserStock.StockSymbol,
                Value = (decimal)(request.UserStock.Quantity * request.UserStock.Price)
            };

            await _transactionRepository.Add(transaction);

            return _mapper.Map<UserStockDTO>(existingStock);
        }

        [HttpPost("SellStockByUser")]
        public async Task<UserStockDTO> SellStockByUser(BuySellStockRequest request)
        {
            var user = await _userRepository.GetUserByName(request.UserName);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var userStocks = await _userStockRepository.GetUserStocksByUserName(request.UserName);
            var existingStock = userStocks.Where(x => x.StockSymbol == request.UserStock.StockSymbol).FirstOrDefault();

            if (existingStock is null)
            {
                throw new Exception("User stock not found");
            }

            if (existingStock.Quantity < request.UserStock.Quantity)
            {
                throw new Exception("Not enough stock quantity");
            }

            var cashToAdd = request.UserStock.Quantity * request.UserStock.Price;
            user.AccountBalance += (decimal)cashToAdd;
            await _userRepository.Update(user);

            existingStock.Quantity -= request.UserStock.Quantity;
            await _userStockRepository.Update(existingStock);


            Transaction transaction = new Transaction()
            {
                UserId = user.UserId,
                Quantity = request.UserStock.Quantity,
                StockSymbol = request.UserStock.StockSymbol,
                Value = -(decimal)(request.UserStock.Quantity * request.UserStock.Price)
            };

            await _transactionRepository.Add(transaction);


            return _mapper.Map<UserStockDTO>(existingStock);
        }
    }
}
