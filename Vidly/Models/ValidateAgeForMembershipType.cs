using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Vidly.Models
{
    public class ValidateAgeForMembershipType:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cusInstance = (Customer) validationContext.ObjectInstance;


            if (cusInstance.MembershipTypeId == MembershipType.Unknown ||
                cusInstance.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (cusInstance.Birthdate == null)
            {
                return new ValidationResult("Bithdate is required");
            }

            var age = DateTime.Now.Year - cusInstance.Birthdate.Value.Year;
           return (age>=18)
               ?ValidationResult.Success
               :new ValidationResult("Bithdate should be greater than 18");
        }
    }
}