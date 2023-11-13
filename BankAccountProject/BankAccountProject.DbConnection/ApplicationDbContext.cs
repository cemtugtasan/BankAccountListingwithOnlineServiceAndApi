using BankAccountProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAccountProject.DbConnection
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BankAccount> BankAccounts { get; set; }

        
    }
}
