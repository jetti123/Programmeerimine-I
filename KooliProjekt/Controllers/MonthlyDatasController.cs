using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class MonthlyDatasController : Controller
    {
        private readonly IMonthlyDataService _monthlyDataService;
        private readonly IAssetService _assetService;

        public MonthlyDatasController(IMonthlyDataService monthlyDataService, IAssetService assetService)
        {
            _monthlyDataService = monthlyDataService;
            _assetService = assetService;
        }

        // GET: MonthlyDatas
        public async Task<IActionResult> Index()
        {
            var monthlyData = await _monthlyDataService.GetAllWithAssetAsync();
            return View(monthlyData);
        }

        // GET: MonthlyDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _monthlyDataService.GetByIdWithAssetAsync(id.Value);
            if (monthlyData == null)
            {
                return NotFound();
            }

            return View(monthlyData);
        }

        // GET: MonthlyDatas/Create
        public async Task<IActionResult> Create()
        {
            var assets = await _assetService.GetAllAsync();
            ViewData["AssetId"] = new SelectList(assets, "Id", "Name");
            return View();
        }

        // POST: MonthlyDatas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetId,Date,Quantity,Value")] MonthlyData monthlyData)
        {
            if (ModelState.IsValid)
            {
                await _monthlyDataService.AddAsync(monthlyData);
                return RedirectToAction(nameof(Index));
            }

            var assets = await _assetService.GetAllAsync();
            ViewData["AssetId"] = new SelectList(assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // GET: MonthlyDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _monthlyDataService.GetByIdAsync(id.Value);
            if (monthlyData == null)
            {
                return NotFound();
            }

            var assets = await _assetService.GetAllAsync();
            ViewData["AssetId"] = new SelectList(assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // POST: MonthlyDatas/Edit/5
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
                    await _monthlyDataService.UpdateAsync(monthlyData);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return BadRequest();
                }
            }

            var assets = await _assetService.GetAllAsync();
            ViewData["AssetId"] = new SelectList(assets, "Id", "Name", monthlyData.AssetId);
            return View(monthlyData);
        }

        // GET: MonthlyDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monthlyData = await _monthlyDataService.GetByIdWithAssetAsync(id.Value);
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
            await _monthlyDataService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

