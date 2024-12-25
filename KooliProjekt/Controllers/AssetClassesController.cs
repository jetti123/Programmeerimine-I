using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class AssetClassesController : Controller
    {
        private readonly IAssetClassService _assetClassService;

        public AssetClassesController(IAssetClassService assetClassService)
        {
            _assetClassService = assetClassService;
        }

        // GET: AssetClasses
        public async Task<IActionResult> Index()
        {
            var assetClasses = await _assetClassService.GetAllAsync();
            return View(assetClasses);
        }

        // GET: AssetClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetClass = await _assetClassService.GetByIdAsync(id.Value);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AssetClass assetClass)
        {
            if (ModelState.IsValid)
            {
                await _assetClassService.AddAsync(assetClass);
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

            var assetClass = await _assetClassService.GetByIdAsync(id.Value);
            if (assetClass == null)
            {
                return NotFound();
            }
            return View(assetClass);
        }

        // POST: AssetClasses/Edit/5
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
                    await _assetClassService.UpdateAsync(assetClass);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return BadRequest();
                }
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

            var assetClass = await _assetClassService.GetByIdAsync(id.Value);
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
            await _assetClassService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

