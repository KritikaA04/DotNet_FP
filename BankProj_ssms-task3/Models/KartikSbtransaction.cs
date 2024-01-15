using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class KartikSbtransaction
{
    public int TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public double? Amount { get; set; }

    public string? TransactionType { get; set; }
}
