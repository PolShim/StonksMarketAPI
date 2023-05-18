using System;
using System.Collections.Generic;

namespace StonksMarket.Core.StonksDbModels;

public partial class User
{
    public int UserId { get; set; }

    public long AccountBalance { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<UserStock> UserStocks { get; set; } = new List<UserStock>();
}
