using AutoMapper;
using StonksMarket.Core.StonksDbModels;
using StonksMarket.Infrastructure.DTOs;
using StonksMarket.Infrastructure.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<UserStock,UserStockBuySellDTO>().ReverseMap();
            CreateMap<UserStock,UserStockDTO>().ReverseMap();
            CreateMap<Transaction,TransactionDTO>().ReverseMap();
        }
    }
}
