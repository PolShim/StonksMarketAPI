using System;
using System.Collections.Generic;

namespace StonksMarket.Core.StonksDbModels;

public partial class UserStock
{
    public int Id { get; set; }

    public string StockSymbol { get; set; } = null!;

    public long Quantity { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
