using System;
using System.Collections.Generic;

namespace flightmvc.Models;

public partial class KritikaFlight
{
    public int FlightId { get; set; }

    public string? FlightName { get; set; }

    public string? Airline { get; set; }

    public string? Source { get; set; }

    public string? Destination { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<KritikaBooking> KritikaBookings { get; set; } = new List<KritikaBooking>();
}
