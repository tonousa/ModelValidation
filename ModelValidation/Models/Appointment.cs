using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    [NoJoeOnMoondays]
    public class Appointment
    {
        [Required]
        public string ClientName { get; set; }

        //[Required(ErrorMessage="Please enter a date")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage="Please enter a date in the future")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage="You must accept the terms")]
        [MustBeTrue(ErrorMessage="You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}