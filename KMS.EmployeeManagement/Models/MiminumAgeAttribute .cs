using System;
using System.ComponentModel.DataAnnotations;

namespace KMS.EmployeeManagement.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MiminumAgeAttribute : ValidationAttribute
    {
      
        private readonly string dateOfBirthProperty;
        private readonly int miniumAge;

        public MiminumAgeAttribute(string dobPropertyName, int minimumAge)
        {
            if (string.IsNullOrEmpty(dobPropertyName))
            {
                throw new ArgumentNullException("Dob is not allow to null");
            }
            dateOfBirthProperty = dobPropertyName;
            miniumAge = minimumAge;
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime startDate = Convert.ToDateTime(value);

            var dobPropertyName = validationContext.ObjectInstance.GetType().GetProperty(dateOfBirthProperty);
            var dobPropertyValue = dobPropertyName.GetValue(validationContext.ObjectInstance, null);
            DateTime dateOfBirth = Convert.ToDateTime(dobPropertyValue);
            int age = startDate.Year - dateOfBirth.Year;
            if (age < miniumAge)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}