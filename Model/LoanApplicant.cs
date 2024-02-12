using MartinHuiLoanApplicationApi.Attributes;
using System.ComponentModel.DataAnnotations;


namespace MartinHuiLoanApplicationApi.Model
{
    public class LoanApplicant
    {
        // Unique identifier for each applicant
        [Key]
        public int ApplicantID
        {
            get;
            internal set; //prevent value being set from incoming request
        }

        // Applicant's first name
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        // Applicant's last name
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        // Applicant's residential address
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        // Applicant's city
        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        // Applicant's state or province
        [MaxLength(50)]
        public string? State { get; set; }

        // Applicant's country
        [Required]
        [MaxLength(2)]
        [CountryTwoLetterISOName]
        public string Country { get; set; }

        // Applicant's postal code or ZIP code
        // UK postcode regex: https://stackoverflow.com/questions/17012628/uk-postcode-regex
        // Nuget Postcode checker: https://stackoverflow.com/questions/29266586/how-can-i-validate-worldwide-postal-codes-in-my-net-code
        [Required]
        [RegularExpression(@"^[\w\s-]{1,10}$", ErrorMessage = "Invalid postal code.")]
        public string PostalCode { get; set; }

        // Applicant's date of birth
        [Required]
        [DateOfBirth(Min = 16, Max = 150)]
        public DateTime DateOfBirth { get; set; }

        // Applicant's annual income
        [Required]
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal AnnualIncome { get; set; }

        // Applicant's email address
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        // Applicant's phone number
        [MaxLength(20)]
        [Phone]
        public string? PhoneNumber { get; set; }


        // Applicant's gender
        [StringRange(AcceptedValues = new string[] { "M", "F", "TM", "TF", "N", "PN" }, ErrorMessage = "The accepted value are: M (male), F (female), TM (Trans-male), TF (Trans-female), N (Netural), PN (Preferred Not to say)")]
        public string? Gender { get; set; }


        // Applicant's employment status (e.g., employed, self-employed, unemployed)
        [MaxLength(50)]
        public string? EmploymentStatus { get; set; }


        // Applicant's credit score
        [Range(0, 999)]
        public int CreditScore { get; set; }

        // Applicant's existing debts (if any)
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal ExistingDebts { get; set; }

        // Applicant's desired loan amount
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal DesiredLoanAmount { get; set; }

        // Applicant's desired loan term (e.g., 12 months, 24 months)
        [Range(0,1000)]
        public int DesiredLoanTermMonths { get; set; }

        // Timestamp indicating when the application was submitted
        public DateTime SubmittedDate
        {
            get;
            internal set;
        }

        public LoanApplicant()
        {

        }
    }

}
