using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ModelValidation.Infrastructure;

namespace ModelValidation.Models
{
    [NoJoeOnMoondays]
    //public class Appointment : IValidatableObject
    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength=3)]
        public string ClientName { get; set; }

        //[Required(ErrorMessage="Please enter a date")]
        //[FutureDate(ErrorMessage="Please enter a date in the future")]
        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage="You must accept the terms")]
        //[MustBeTrue(ErrorMessage = "You must accept the terms (IValidatableObject)")]
        public bool TermsAccepted { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext 
            validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(ClientName))
            {
                errors.Add(new ValidationResult("Please enter your name"));
            }

            if (DateTime.Now > Date)
            {
                errors.Add(new ValidationResult("Please enter date in future"));
            }

            if (errors.Count == 0 && ClientName == "Joe" 
                && Date.DayOfWeek == DayOfWeek.Monday)
	        {
                errors.Add(new ValidationResult("Joe cannot book on Mondays"));
	        }

            if (!TermsAccepted)
	        {
		        errors.Add(new ValidationResult("You must accept terms"));
	        }

            return errors;
        }
    }
}