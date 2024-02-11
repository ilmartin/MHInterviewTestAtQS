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
        private readonly ILogger<PrequalificationController> _logger;

        public PrequalificationController(ApplicationDbContext context, LoanProductService loanProductService, ILogger<PrequalificationController> logger)
        {
            _context = context;
            _loanProductService = loanProductService;
            _logger = logger;
        }

        // POST: api/prequalification
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<LoanProduct>>> PostPrequalification(LoanApplicant applicant)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                _logger.LogError("Incoming data is invalid. Errors: {errors}", errors);
                return BadRequest(errors);
            }
            _logger.LogInformation($"{nameof(PostPrequalification)} method called");
            if (_context.LoanApplicants == null)
            {
                _logger.LogError($"LoanApplicants object from DBContext is null");
                return BadRequest("Unfortunately, the system has failed to process your data. Please try again.");
            }
            try
            {
                applicant.SubmittedDate = DateTime.Now;
                _context.LoanApplicants.Add(applicant);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Insert Entity 'ApplicationDbContext.LoanApplicants' failed, error {e}",e);
                return BadRequest("Unfortunately, the system has failed to process your data. Please try again.");
            }
            try
            {
                var result = _loanProductService.GetQualifiedLoanProducts(applicant);
                if (!result.Any())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to retrieve data from Qualified Loan Products for applicant, error {e}", e);
                //delete the applicant data if failed
                _context.LoanApplicants.Remove(applicant);
                await _context.SaveChangesAsync();
                return BadRequest("Unfortunately, the system has failed to process your data. Please try again.");
            }
        }
    }
}
