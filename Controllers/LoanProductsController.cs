using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MartinHuiLoanApplicationApi.Model;

namespace MartinHuiLoanApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/LoanProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanProduct>>> GetLoanProducts()
        {
            if (_context.LoanProducts == null)
            {
                return NotFound();
            }
            return await _context.LoanProducts.ToListAsync();
        }

        // GET: api/LoanProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanProduct>> GetLoanProduct(int id)
        {
            if (_context.LoanProducts == null)
            {
                return NotFound();
            }
            var loanProduct = await _context.LoanProducts.FindAsync(id);

            if (loanProduct == null)
            {
                return NotFound();
            }

            return loanProduct;
        }

        // PUT: api/LoanProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanProduct(int id, LoanProduct loanProduct)
        {
            if (id != loanProduct.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(loanProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanProduct>> PostLoanProduct(LoanProduct loanProduct)
        {
            if (_context.LoanProducts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LoanProducts' is null.");
            }
            _context.LoanProducts.Add(loanProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanProduct", new { id = loanProduct.ProductID }, loanProduct);
        }

        // DELETE: api/LoanProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanProduct(int id)
        {
            if (_context.LoanProducts == null)
            {
                return NotFound();
            }
            var loanProduct = await _context.LoanProducts.FindAsync(id);
            if (loanProduct == null)
            {
                return NotFound();
            }

            _context.LoanProducts.Remove(loanProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanProductExists(int id)
        {
            return (_context.LoanProducts?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
