-- Delete Table Script if required
--IF OBJECT_ID('MartinHuiDatabase.dbo.LoanProducts', 'U') IS NOT NULL
--BEGIN
--    DROP TABLE MartinHuiDatabase.dbo.LoanProducts;
--END

-- Create a table for loan products (credit cards)
CREATE TABLE MartinHuiDatabase.dbo.LoanProducts (
    -- Unique identifier for each loan product
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    
    -- Name or description of the loan product
    ProductName VARCHAR(100),
    
    -- Financial institution or organization that issues the loan product
    Issuer VARCHAR(100),
    
    -- Annual interest rate associated with the loan product
    InterestRate DECIMAL(5, 2),
    
    -- Any annual fees associated with the loan product
    AnnualFee DECIMAL(10, 2),
	
    -- Minimum salary required to be eligible for the loan product
    MinimumAnnualSalary INT,
    
    -- Minimum credit score required to be eligible for the loan product
    MinimumCreditScore INT,
    
    -- Indicates whether the loan product includes a rewards program
    RewardsProgram BIT,
    
    -- Introductory annual percentage rate (APR) offered for a certain period
    IntroductoryAPR DECIMAL(5, 2),
    
    -- Duration of the introductory APR period
    IntroductoryPeriod INT,
    
    -- Maximum amount of credit extended to the cardholder
    CreditLimit DECIMAL(10, 2),
    
    -- Period during which no interest is charged on new purchases if the balance is paid in full
    GracePeriod INT,
    
    -- Fee charged for late payments
    LatePaymentFee DECIMAL(10, 2),
    
    -- Fees associated with transactions made in foreign currencies
    ForeignTransactionFee DECIMAL(5, 2),
    
    -- Fee charged for transferring a balance from another credit card
    BalanceTransferFee DECIMAL(5, 2),
    
    -- Fee charged for cash advances
    CashAdvanceFee DECIMAL(5, 2),
    
    -- Minimum percentage of the outstanding balance that must be paid each billing cycle
    MinimumPaymentPercentage DECIMAL(5, 2),
    
    -- Additional terms and conditions associated with the loan product [ignore to save storage for my laptop]
    TermsAndConditions TEXT
);

-- Create an index to increase efficency when returning the qualified product
CREATE INDEX idx_MinimumAnnualSalary ON LoanProducts (MinimumAnnualSalary);
