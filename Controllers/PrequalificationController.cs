using MartinHuiLoanApplicationApi.Model;
using MartinHuiLoanApplicationApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MartinHuiLoanApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrequalificationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly LoanProductService _loanProductService;

        public PrequalificationController(ApplicationDbContext context, LoanProductService loanProductService)
        {
            _context = context;
            _loanProductService = loanProductService;
        }

        // POST: api/prequalification
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<LoanProduct>>> PostPrequalification(LoanApplicant applicant)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return BadRequest(errors);
            }
            if (_context.LoanApplicants == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LoanApplicants'  is null.");
            }
            try
            {
                applicant.SubmittedDate = DateTime.Now;
                _context.LoanApplicants.Add(applicant);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Problem("Insert Entity 'ApplicationDbContext.LoanApplicants' failed");
            }

            return Ok(_loanProductService.GetQualifiedLoanProducts(applicant));
        }
    }
}
