using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StonksMarket.Core.Repository;
using StonksMarket.Core.StonksDbModels;
using StonksMarket.Infrastructure.DTOs;

namespace StonksMarket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
        }

        [HttpPut("AddNewUser")]
        public async Task<UserDTO> AddUser(string userName)
        {
            var newUser = new User()
            {
                AccountBalance = 100000,
                Name = userName
            };
            return _mapper.Map<UserDTO>(await _userRepository.Add(newUser));
        }

        [HttpPut("ResetUser")]
        public async Task<UserDTO> ResetUser(string userName)
        {
           var existingUser = await _userRepository.GetUserByName(userName);

            if(existingUser is null) 
            {
                throw new Exception("User not found");
            }

            return _mapper.Map<UserDTO>(await _userRepository.Update(existingUser));
        }
    }
}
