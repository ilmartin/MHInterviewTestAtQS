﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MartinHuiLoanApplicationApi.Model
{
    public class LoanApplicant
    {
        // Unique identifier for each applicant
        [Key]
        public int ApplicantID { get; set; }

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
        [MaxLength(50)]
        public string Country { get; set; }

        // Applicant's postal code or ZIP code
        [Required]
        public string PostalCode { get; set; }

        // Applicant's date of birth
        [Required]
        public DateTime DateOfBirth { get; set; }

        // Applicant's annual income
        [Required]
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
        public string? Gender { get; set; }


        // Applicant's employment status (e.g., employed, self-employed, unemployed)
        [MaxLength(50)]
        public string? EmploymentStatus { get; set; }


        // Applicant's credit score
        [Range(0,999)]
        public int CreditScore { get; set; }

        // Applicant's existing debts (if any)
        public decimal ExistingDebts { get; set; }

        // Applicant's desired loan amount
        public decimal DesiredLoanAmount { get; set; }

        // Applicant's desired loan term (e.g., 12 months, 24 months)
        public int DesiredLoanTermMonths { get; set; }

        // Timestamp indicating when the application was submitted
        public DateTime SubmittedDate { get; set; }

        public LoanApplicant()
        {
                
        }
    }

}