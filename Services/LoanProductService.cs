using MartinHuiLoanApplicationApi.Model;
using Microsoft.EntityFrameworkCore;

namespace MartinHuiLoanApplicationApi.Services
{
    public class LoanProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public LoanProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal IQueryable<LoanProduct> GetQualifiedLoanProducts(LoanApplicant applicant)
        {
            return from product in _dbContext.LoanProducts
                   where applicant.AnnualIncome >= product.MinimumAnnualSalary
                   select product;
        }
    }
}
