using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flightmvc.Models;

public partial class KritikaCustomer
{
    public int CustomerId { get; set; }

    [Display(Name = "Customer Name")]
    [Required(ErrorMessage = "Customer name is mandatory")]
    public string? CustomerName { get; set; }

    [Display(Name = "Email Address")]
    [Required(ErrorMessage ="Please enter an email")]
    [DataType(DataType.EmailAddress,ErrorMessage ="Please enter a valid email address")]
    public string? CustomerEmail { get; set; }
    [Display(Name = "Customer Location")]
    public string? Loc { get; set; }
    [Display(Name = "Password")]
    [Required(ErrorMessage ="Password is required")]
    public string? Password { get; set; }

    public virtual ICollection<KritikaBooking> KritikaBookings { get; set; } = new List<KritikaBooking>();
}
