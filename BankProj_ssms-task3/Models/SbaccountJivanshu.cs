using System;
using System.Collections.Generic;

namespace bankproj.Models;

public partial class SbaccountJivanshu
{
    public int Accountnumber { get; set; }

    public string? Customername { get; set; }

    public string? Customeraddress { get; set; }

    public decimal? Currentbalance { get; set; }

    public virtual ICollection<SbtransactionsJivanshu> SbtransactionsJivanshus { get; set; } = new List<SbtransactionsJivanshu>();
}
