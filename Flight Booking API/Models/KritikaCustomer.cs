using System;
using System.Collections.Generic;

namespace flightapi.Models;

public partial class KritikaCustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerEmail { get; set; }

    public string? Loc { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<KritikaBooking> KritikaBookings { get; set; } = new List<KritikaBooking>();
}
