using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using KooliProjekt.Data;
using KooliProjekt.Services;
using KooliProjekt.Models;
using KooliProjekt.Search;

namespace KooliProjekt.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IAssetService _assetService;
        private readonly IAssetClassService _assetClassService;

        public AssetsController(IAssetService assetService, IAssetClassService assetClassService)
        {
            _assetService = assetService;
            _assetClassService = assetClassService;
        }

        // GET: Assets
        public async Task<IActionResult> Index(AssetSearch search)
        {
            var assets = await _assetService.ListAsync(search);
            var assetClasses = await _assetClassService.GetAllAsync();

            var model = new AssetIndexModel
            {
                Assets = assets,
                Search = search,
                AssetClasses = assetClasses
            };

            return View(model);
        }

        // GET: Assets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _assetService.GetByIdWithAssetClassAsync(id.Value);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // GET: Assets/Create
        public async Task<IActionResult> Create()
        {
            var assetClasses = await _assetClassService.GetAllAsync();
            ViewData["AssetClassId"] = new SelectList(assetClasses, "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AssetClassId")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                await _assetService.AddAsync(asset);
                return RedirectToAction(nameof(Index));
            }

            var assetClasses = await _assetClassService.GetAllAsync();
            ViewData["AssetClassId"] = new SelectList(assetClasses, "Id", "Name", asset.AssetClassId);
            return View(asset);
        }

        // GET: Assets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _assetService.GetByIdAsync(id.Value);
            if (asset == null)
            {
                return NotFound();
            }

            var assetClasses = await _assetClassService.GetAllAsync();
            ViewData["AssetClassId"] = new SelectList(assetClasses, "Id", "Name", asset.AssetClassId);
            return View(asset);
        }

        // POST: Assets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AssetClassId")] Asset asset)
        {
            if (id != asset.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _assetService.UpdateAsync(asset);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log error if necessary
                    return BadRequest();
                }
            }

            var assetClasses = await _assetClassService.GetAllAsync();
            ViewData["AssetClassId"] = new SelectList(assetClasses, "Id", "Name", asset.AssetClassId);
            return View(asset);
        }

        // GET: Assets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asset = await _assetService.GetByIdWithAssetClassAsync(id.Value);
            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _assetService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

