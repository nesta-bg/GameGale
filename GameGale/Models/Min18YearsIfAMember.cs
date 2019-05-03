using System;
using System.ComponentModel.DataAnnotations;

namespace GameGale.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            //Value because Birthdate is a nullable data type 
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
               ? ValidationResult.Success
               : new ValidationResult("Customer should be at least 18 years old to go on a membership");
        }
    }
}