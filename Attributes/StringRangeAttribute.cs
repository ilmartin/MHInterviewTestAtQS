using System.ComponentModel.DataAnnotations;

namespace MartinHuiLoanApplicationApi.Attributes
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AcceptedValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AcceptedValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"The accepted values are: {string.Join(", ", (AcceptedValues ?? new string[] { "No accepted values is available" }))}.";
            return new ValidationResult(msg);
        }
    }
}
