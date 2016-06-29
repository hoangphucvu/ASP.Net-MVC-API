using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KMS.EmployeeManagement.Models
{
    public class MiminumAgeAttribute : ValidationAttribute
    {
        private const int MinAge = 22;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = validationContext.ObjectInstance as Employee;

            if (employee.StartDate.Year - employee.DOB.Year < MinAge)
            {
                return new ValidationResult(string.Format("{0} {1} {2}", "Employee must be from", MinAge.ToString(), "years old"));
            }
            return ValidationResult.Success;
        }
    }
}