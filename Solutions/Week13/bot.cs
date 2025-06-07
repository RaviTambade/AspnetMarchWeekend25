// LoanBot API - Starter Template (ASP.NET Core 8)
// Project Structure:
// - LoanBot.Api (Web API Project)
// - LoanBot.Core (Business Models & Interfaces)
// - LoanBot.Infrastructure (EF Core + Seed Data)
// - RabbitMQ integration for LoanApplication events (Publisher + Consumer)

// -----------------------------
// File: Loan.cs (in LoanBot.Core)
namespace LoanBot.Core.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public double Interest { get; set; }
        public double ProcessingFee { get; set; }
    }

    public class UserProfile
    {
        public int Age { get; set; }
        public double Income { get; set; }
        public double CibilScore { get; set; }
        public string Location { get; set; } = string.Empty;
    }

    public class EligibilityResult
    {
        public Loan Loan { get; set; }
        public string Reason { get; set; } = string.Empty;
    }

    public class LoanApplicationEvent
    {
        public string Applicant { get; set; } = string.Empty;
        public string LoanType { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    public class LoanApplication
    {
        public int Id { get; set; }
        public string Applicant { get; set; } = string.Empty;
        public string LoanType { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}

// -----------------------------

// -----------------------------


// -----------------------------


// -----------------------------
