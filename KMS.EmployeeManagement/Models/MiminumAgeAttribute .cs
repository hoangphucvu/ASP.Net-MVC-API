using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KMS.EmployeeManagement.Models
{
    public class MiminumAgeAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Employee employee = new Employee();
            int minAge = 22;
            if ((DateTime.Parse(value.ToString()).Year - employee.DOB.Year) < minAge)
            {
                return new ValidationResult("You must be 22 year old or older");
            }
            return ValidationResult.Success;
        }
    }
}