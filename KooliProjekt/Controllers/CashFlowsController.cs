using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data;

namespace KooliProjekt.Controllers
{
    public class CashFlowsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CashFlowsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CashFlows
        public async Task<IActionResult> Index()
        {
            return View(await _context.CashFlows.ToListAsync());
        }

        // GET: CashFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlow == null)
            {
                return NotFound();
            }

            return View(cashFlow);
        }

        // GET: CashFlows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CashFlows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description")] CashFlow cashFlow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cashFlow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cashFlow);
        }

        // GET: CashFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlows.FindAsync(id);
            if (cashFlow == null)
            {
                return NotFound();
            }
            return View(cashFlow);
        }

        // POST: CashFlows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Amount,Description")] CashFlow cashFlow)
        {
            if (id != cashFlow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cashFlow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CashFlowExists(cashFlow.Id))
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
            return View(cashFlow);
        }

        // GET: CashFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _context.CashFlows
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cashFlow == null)
            {
                return NotFound();
            }

            return View(cashFlow);
        }

        // POST: CashFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cashFlow = await _context.CashFlows.FindAsync(id);
            if (cashFlow != null)
            {
                _context.CashFlows.Remove(cashFlow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CashFlowExists(int id)
        {
            return _context.CashFlows.Any(e => e.Id == id);
        }
    }
}
