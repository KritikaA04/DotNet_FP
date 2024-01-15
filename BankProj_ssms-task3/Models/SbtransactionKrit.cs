using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbtransactionKrit
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public decimal? Amount { get; set; }

    public string? Transactiontype { get; set; }

    public virtual SbaccountKrit? AccountNumberNavigation { get; set; }
}
