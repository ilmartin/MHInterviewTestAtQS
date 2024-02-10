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
        public int ProductID { get; set; }

        // Name or description of the loan product
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        // Financial institution or organization that issues the loan product
        [Required]
        [MaxLength(100)]
        public string Issuer { get; set; }

        // Annual interest rate associated with the loan product
        [Required]
        public decimal InterestRate { get; set; }

        // Any annual fees associated with the loan product
        [Required]
        public decimal AnnualFee { get; set; }

        // Minimum salary required to be eligible for the loan product
        [Required]
        public int MinimumAnnualSalary { get; set; }

        // Minimum credit score required to be eligible for the loan product
        [Required]
        public int MinimumCreditScore { get; set; }

        // Indicates whether the loan product includes a rewards program
        [Required]
        public bool RewardsProgram { get; set; }

        // Introductory annual percentage rate (APR) offered for a certain period
        [Required]
        public decimal IntroductoryAPR { get; set; }

        // Duration of the introductory APR period
        [Required]
        public int IntroductoryPeriod { get; set; }

        // Maximum amount of credit extended to the cardholder
        [Required]
        public decimal CreditLimit { get; set; }

        // Period during which no interest is charged on new purchases if the balance is paid in full
        [Required]
        public int GracePeriod { get; set; }

        // Fee charged for late payments
        [Required]
        public decimal LatePaymentFee { get; set; }

        // Fees associated with transactions made in foreign currencies
        [Required]
        public decimal ForeignTransactionFee { get; set; }

        // Fee charged for transferring a balance from another credit card
        [Required]
        public decimal BalanceTransferFee { get; set; }

        // Fee charged for cash advances
        [Required]
        public decimal CashAdvanceFee { get; set; }

        // Minimum percentage of the outstanding balance that must be paid each billing cycle
        [Required]
        public decimal MinimumPaymentPercentage { get; set; }

        // Additional terms and conditions associated with the loan product
        [AllowNull]
        public string TermsAndConditions { get; set; } = "";

        public LoanProduct()
        {
                
        }

        internal bool IsQualified(LoanApplicant applicant)
        {
            return applicant.AnnualIncome >= this.MinimumAnnualSalary;
        }
    }

}
