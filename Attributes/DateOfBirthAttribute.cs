using System.ComponentModel.DataAnnotations;

namespace MartinHuiLoanApplicationApi.Attributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int Min { get; set; }
        public int Max { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var val = (DateTime)value;
            var currentTime = DateTime.Now;
            if (val.AddYears(Min) > currentTime)
                return new ValidationResult($"The applicant must be at least {Min} years old to apply for a loan product.");
            if (val.AddYears(Max) > currentTime)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"The applicant must be less then {Max} years old to apply for a loan product.");
        }
    }
}
