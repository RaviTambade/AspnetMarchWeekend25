// File: LoansController.cs (in LoanBot.Api)
using LoanBot.Core.Models;
using LoanBot.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanBot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly RabbitMQPublisher _publisher;

        public LoansController(AppDbContext context)
        {
            _context = context;
            _publisher = new RabbitMQPublisher();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Loans.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            return loan == null ? NotFound() : Ok(loan);
        }

        [HttpPost("eligibility/check")]
        public async Task<IActionResult> CheckEligibility([FromBody] UserProfile profile)
        {
            var loans = await _context.Loans.ToListAsync();
            var eligible = new List<EligibilityResult>();

            foreach (var loan in loans)
            {
                if (profile.CibilScore >= 700 && profile.Income >= 30000)
                {
                    eligible.Add(new EligibilityResult
                    {
                        Loan = loan,
                        Reason = "Eligible based on good CIBIL and income."
                    });
                }
                else
                {
                    eligible.Add(new EligibilityResult
                    {
                        Loan = loan,
                        Reason = "Not eligible: insufficient CIBIL or income."
                    });
                }
            }

            return Ok(eligible);
        }

        [HttpPost("apply")]
        public IActionResult Apply([FromBody] LoanApplicationEvent appEvent)
        {
            _publisher.Publish(appEvent);
            return Ok(new { status = "Loan application event published successfully." });
        }
    }
}