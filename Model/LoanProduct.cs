using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MartinHuiLoanApplicationApi.Model
{

    public class LoanProduct
    {
        // Unique identifier for each loan product
        [Required]
        [Key]
        public int ProductID
        {
            get;
            internal set;
        }

        // Name or description of the loan product
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string ProductName { get; set; }

        // Financial institution or organization that issues the loan product
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Issuer { get; set; }

        // Annual interest rate associated with the loan product
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal InterestRate { get; set; }

        // Any annual fees associated with the loan product
        [Required]
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal AnnualFee { get; set; }

        // Minimum salary required to be eligible for the loan product
        [Required]
        [Range(minimum:0, maximum:int.MaxValue)]
        public int MinimumAnnualSalary { get; set; }

        // Minimum credit score required to be eligible for the loan product
        [Required]
        [Range(minimum:0, maximum:int.MaxValue)]
        public int MinimumCreditScore { get; set; }

        // Indicates whether the loan product includes a rewards program
        [Required]
        public bool RewardsProgram { get; set; }

        // Introductory annual percentage rate (APR) offered for a certain period
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal IntroductoryAPR { get; set; }

        // Duration of the introductory APR period
        [Required]
        [Range(minimum:0,maximum:1000)]
        public int IntroductoryPeriod { get; set; }

        // Maximum amount of credit extended to the cardholder
        [Required]
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal CreditLimit { get; set; }

        // Period during which no interest is charged on new purchases if the balance is paid in full
        [Required]
        [Range(minimum:0,maximum:1000)]
        public int GracePeriod { get; set; }

        // Fee charged for late payments
        [Required]
        [Range(minimum: 0.0, maximum: 9999999.99)]
        public decimal LatePaymentFee { get; set; }

        // Fees associated with transactions made in foreign currencies
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal ForeignTransactionFee { get; set; }

        // Fee charged for transferring a balance from another credit card
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal BalanceTransferFee { get; set; }

        // Fee charged for cash advances
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal CashAdvanceFee { get; set; }

        // Minimum percentage of the outstanding balance that must be paid each billing cycle
        [Required]
        [Range(minimum:0.0,maximum:999.99)]
        public decimal MinimumPaymentPercentage { get; set; }

        // Additional terms and conditions associated with the loan product
        [StringLength(int.MaxValue)]
        public string? TermsAndConditions { get; set; } = "";

        public LoanProduct()
        {
                
        }

        internal bool IsQualified(LoanApplicant applicant)
        {
            return applicant.AnnualIncome >= this.MinimumAnnualSalary;
        }
    }

}
