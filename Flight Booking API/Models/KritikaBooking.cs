using System;
using System.Collections.Generic;

namespace flightapi.Models;

public partial class KritikaBooking
{
    public int BookingId { get; set; }

    public int? FlightId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? BookingDate { get; set; }

    public int? NoOfPassengers { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual KritikaCustomer? Customer { get; set; }

    public virtual KritikaFlight? Flight { get; set; }
}
