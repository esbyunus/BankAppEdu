using BankAppApi.Data;
using BankAppApi.Data.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly BankContext _context;

        public DashBoardController(BankContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardData()
        {
            var userCount = await _context.Users.CountAsync();
            var totalBalance = await _context.Accounts.SumAsync(a => a.Balance);
            var fixedAccounts = await _context.Accounts.CountAsync(a => a.Type == AccountType.vadeli);

            // Vadesiz hesap sayısı
            var currentAccounts = await _context.Accounts.CountAsync(a => a.Type == AccountType.vadesiz);
            var approvedApplications = await _context.Applications.CountAsync(a => a.IsApprovel);
            var rejectedApplications = await _context.Applications.CountAsync(a => !a.IsApprovel && !a.Pending);

            var result = new
            {
                ApprovedApplications = approvedApplications,
                RejectedApplications = rejectedApplications,
                UserCount = userCount,
                TotalBalance = totalBalance,
                FixedAccounts = fixedAccounts,
                CurrentAccounts = currentAccounts
            };

            return Ok(result);
        }
    }
}
