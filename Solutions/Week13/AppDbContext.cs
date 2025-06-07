// File: AppDbContext.cs (in LoanBot.Infrastructure)
using LoanBot.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanBot.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<LoanApplication> LoanApplications => Set<LoanApplication>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasData(
                new Loan { Id = 1, Type = "Home Loan", Bank = "Axis Bank", Interest = 7.8, ProcessingFee = 2000 },
                new Loan { Id = 2, Type = "Personal Loan", Bank = "HDFC", Interest = 10.5, ProcessingFee = 500 },
                new Loan { Id = 3, Type = "Car Loan", Bank = "ICICI", Interest = 9.2, ProcessingFee = 1000 }
            );
        }
    }
}
