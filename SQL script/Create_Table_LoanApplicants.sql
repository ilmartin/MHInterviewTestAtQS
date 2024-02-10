-- Delete Table Script if required
--IF OBJECT_ID('MartinHuiDatabase.dbo.LoanApplicants', 'U') IS NOT NULL
--BEGIN
--    DROP TABLE MartinHuiDatabase.dbo.LoanApplicants;
--END

-- Create a table for storing loan product applicant data
CREATE TABLE MartinHuiDatabase.dbo.LoanApplicants (
    -- Unique identifier for each applicant
    ApplicantID INT PRIMARY KEY IDENTITY(1,1),

    -- Applicant's first name
    FirstName VARCHAR(50) not null,

    -- Applicant's last name
    LastName VARCHAR(50) not null,

    -- Applicant's residential address
    Address VARCHAR(255) not null,

    -- Applicant's city
    City VARCHAR(100) not null,

    -- Applicant's state or province
    State VARCHAR(50),

    -- Applicant's country
    Country VARCHAR(50) not null,

    -- Applicant's postal code or ZIP code
    PostalCode VARCHAR(20) not null,

    -- Applicant's date of birth
    DateOfBirth DATE not null,

    -- Applicant's annual income
    AnnualIncome DECIMAL(10, 2) not null,
	
    -- [Martin reckon needed normally] Applicant's email address
    Email VARCHAR(100),

    -- [Martin reckon needed normally] Applicant's phone number
    PhoneNumber VARCHAR(20),

    -- [Martin reckon needed normally] Applicant's gender
    Gender VARCHAR(10),

    -- [Martin reckon needed normally] Applicant's employment status (e.g., employed, self-employed, unemployed)
    EmploymentStatus VARCHAR(50),


    -- [Martin reckon needed normally] Applicant's credit score
    CreditScore INT,

    -- [Martin reckon needed normally] Applicant's existing debts (if any)
    ExistingDebts DECIMAL(10, 2),

    -- [Martin reckon needed normally] Applicant's desired loan amount
    DesiredLoanAmount DECIMAL(10, 2),

    -- [Martin reckon needed normally] Applicant's desired loan term (e.g., 12 months, 24 months)
    DesiredLoanTermMonths INT,

    -- [Martin reckon needed normally] Timestamp indicating when the application was submitted
    SubmittedDate DATETIME not null
);
