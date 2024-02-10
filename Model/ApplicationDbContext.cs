using Microsoft.EntityFrameworkCore;

namespace MartinHuiLoanApplicationApi.Model
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties for each data model class
        public DbSet<LoanProduct> LoanProducts { get; set; }
        public DbSet<LoanApplicant> LoanApplicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, indexes, etc.
        }
    }

}
