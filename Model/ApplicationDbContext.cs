using Microsoft.EntityFrameworkCore;

namespace MartinHuiLoanApplicationApi.Model
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for each data model class
        public virtual DbSet<LoanProduct> LoanProducts { get; set; }
        public virtual DbSet<LoanApplicant> LoanApplicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc.
        }
    }

}
