using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaccoPortal.Models;

namespace SaccoPortal.Controllers
{
    public class ContributionsController : Controller
    {
        private readonly SaccoPortalContext _context;

        public ContributionsController(SaccoPortalContext context)
        {
            _context = context;
        }

        // GET: Contributions
        public async Task<IActionResult> Index()
        {
            var saccoPortalContext = _context.Contributions.Include(c => c.Member);
            return View(await saccoPortalContext.ToListAsync());
        }

        // GET: Contributions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribution = await _context.Contributions
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.ContributionId == id);
            if (contribution == null)
            {
                return NotFound();
            }

            return View(contribution);
        }

        // GET: Contributions/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
            return View();
        }

        // POST: Contributions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContributionId,MemberId,Amount,Date")] Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contribution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", contribution.MemberId);
            return View(contribution);
        }

        // GET: Contributions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribution = await _context.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", contribution.MemberId);
            return View(contribution);
        }

        // POST: Contributions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContributionId,MemberId,Amount,Date")] Contribution contribution)
        {
            if (id != contribution.ContributionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contribution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContributionExists(contribution.ContributionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", contribution.MemberId);
            return View(contribution);
        }

        // GET: Contributions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contribution = await _context.Contributions
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.ContributionId == id);
            if (contribution == null)
            {
                return NotFound();
            }

            return View(contribution);
        }

        // POST: Contributions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contribution = await _context.Contributions.FindAsync(id);
            if (contribution != null)
            {
                _context.Contributions.Remove(contribution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContributionExists(int id)
        {
            return _context.Contributions.Any(e => e.ContributionId == id);
        }
    }
}
