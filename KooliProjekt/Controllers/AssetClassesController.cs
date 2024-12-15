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
    public class AssetClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssetClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssetClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetClasses.ToListAsync());
        }

        // GET: AssetClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClass = await _context.AssetClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetClass == null)
            {
                return NotFound();
            }

            return View(assetClass);
        }

        // GET: AssetClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AssetClass assetClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetClass);
        }

        // GET: AssetClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClass = await _context.AssetClasses.FindAsync(id);
            if (assetClass == null)
            {
                return NotFound();
            }
            return View(assetClass);
        }

        // POST: AssetClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AssetClass assetClass)
        {
            if (id != assetClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetClassExists(assetClass.Id))
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
            return View(assetClass);
        }

        // GET: AssetClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClass = await _context.AssetClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetClass == null)
            {
                return NotFound();
            }

            return View(assetClass);
        }

        // POST: AssetClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetClass = await _context.AssetClasses.FindAsync(id);
            if (assetClass != null)
            {
                _context.AssetClasses.Remove(assetClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetClassExists(int id)
        {
            return _context.AssetClasses.Any(e => e.Id == id);
        }
    }
}
