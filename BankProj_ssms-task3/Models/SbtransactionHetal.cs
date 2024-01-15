using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbtransactionHetal
{
    public int TransactionId { get; set; }

    public DateTime TransactionDate { get; set; }

    public int AccountNo { get; set; }

    public double? Amount { get; set; }

    public string TransactionType { get; set; } = null!;
}
