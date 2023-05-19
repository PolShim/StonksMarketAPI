using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StonksMarket.Core.Repository;
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
    }
}
