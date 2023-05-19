using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StonksMarket.Infrastructure.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public long AccountBalance { get; set; }

        public string? Name { get; set; }
    }
}
