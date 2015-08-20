using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ModelValidation.Models;

namespace ModelValidation.Infrastructure
{
    public class NoJoeOnMoondaysAttribute : ValidationAttribute
    {
        public NoJoeOnMoondaysAttribute()
        {
            ErrorMessage = "Joe cannot book on Mondays";
        }

        public override bool IsValid(object value)
        {
            Appointment app = value as Appointment;
            if (app == null || string.IsNullOrEmpty(app.ClientName) || 
                app.Date == null)
            {
                // we dont have a model of the right type to validate, or we dont
                // hvae the value for the ClientName and Date properties we require
                return true;
            }
            else
            {
                return !(app.ClientName == "Joe" && app.Date.DayOfWeek == DayOfWeek.Monday);
            }
            return base.IsValid(value);
        }
    }
}