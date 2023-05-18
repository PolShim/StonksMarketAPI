using System;
using System.Collections.Generic;

namespace StonksMarket.Core.StonksDbModels;

public partial class Transaction
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string StockSymbol { get; set; } = null!;

    public long Quantity { get; set; }

    public decimal Value { get; set; }

    public virtual User User { get; set; } = null!;
}
