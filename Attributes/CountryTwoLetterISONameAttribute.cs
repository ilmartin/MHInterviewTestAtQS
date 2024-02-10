using MartinHuiLoanApplicationApi.Const;
using System.ComponentModel.DataAnnotations;

namespace MartinHuiLoanApplicationApi.Attributes
{
    public class CountryTwoLetterISONameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var country = value as string;

            var validCountries = Constants.Countries.Select(x=>x.TwoLetterISORegionName);

            if (validCountries.Any(x=>x.Equals(country, StringComparison.OrdinalIgnoreCase)))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please use two letter ISO region code of the country, acceptable values are: "+string.Join(',', validCountries));
        }
    }
}
