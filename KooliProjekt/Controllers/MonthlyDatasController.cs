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
    public class MonthlyDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthlyDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MonthlyDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.MonthlyData.Include(m => m.Asset);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: MonthlyDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _context.MonthlyData
                .Include(m => m.Asset)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyData == null)
            {
                return NotFound();
            }

            return View(monthlyData);
        }

        // GET: MonthlyDatas/Create
        public IActionResult Create()
        {
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name");
            return View();
        }

        // POST: MonthlyDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetId,Date,Quantity,Value")] MonthlyData monthlyData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monthlyData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // GET: MonthlyDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _context.MonthlyData.FindAsync(id);
            if (monthlyData == null)
            {
                return NotFound();
            }
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // POST: MonthlyDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetId,Date,Quantity,Value")] MonthlyData monthlyData)
        {
            if (id != monthlyData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monthlyData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthlyDataExists(monthlyData.Id))
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
            ViewData["AssetId"] = new SelectList(_context.Assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // GET: MonthlyDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _context.MonthlyData
                .Include(m => m.Asset)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monthlyData == null)
            {
                return NotFound();
            }

            return View(monthlyData);
        }

        // POST: MonthlyDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monthlyData = await _context.MonthlyData.FindAsync(id);
            if (monthlyData != null)
            {
                _context.MonthlyData.Remove(monthlyData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonthlyDataExists(int id)
        {
            return _context.MonthlyData.Any(e => e.Id == id);
        }
    }
}
