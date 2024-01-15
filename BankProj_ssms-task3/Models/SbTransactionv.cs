using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbTransactionv
{
    public int TransactionId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public double? Ammount { get; set; }

    public string? TransactionType { get; set; }

    public virtual SbAccountv? AccountNumberNavigation { get; set; }
}
