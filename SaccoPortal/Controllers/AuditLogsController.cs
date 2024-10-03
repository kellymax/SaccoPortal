using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Import the Authorization namespace
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaccoPortal.Models;

namespace SaccoPortal.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict access to Admins
    public class AuditLogsController : Controller
    {
        private readonly SaccoPortalContext _context;

        public AuditLogsController(SaccoPortalContext context)
        {
            _context = context;
        }

        // GET: AuditLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuditLogs.ToListAsync()); // Display all audit logs
        }

        // GET: AuditLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Return not found if no ID is provided
            }

            var auditLog = await _context.AuditLogs
                .FirstOrDefaultAsync(m => m.AuditLogId == id);
            if (auditLog == null)
            {
                return NotFound(); // Return not found if audit log doesn't exist
            }

            return View(auditLog); // Display the details of the audit log
        }

    }
}
