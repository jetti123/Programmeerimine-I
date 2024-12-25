using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KooliProjekt.Data;
using KooliProjekt.Services;

namespace KooliProjekt.Controllers
{
    public class CashFlowsController : Controller
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowsController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        // GET: CashFlows
        public async Task<IActionResult> Index()
        {
            var cashFlows = await _cashFlowService.GetAllAsync();
            return View(cashFlows);
        }

        // GET: CashFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cashFlow = await _cashFlowService.GetByIdAsync(id.Value);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Amount,Description")] CashFlow cashFlow)
        {
            if (ModelState.IsValid)
            {
                await _cashFlowService.AddAsync(cashFlow);
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

            var cashFlow = await _cashFlowService.GetByIdAsync(id.Value);
            if (cashFlow == null)
            {
                return NotFound();
            }

            return View(cashFlow);
        }

        // POST: CashFlows/Edit/5
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
                    await _cashFlowService.UpdateAsync(cashFlow);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log or handle exception
                    return BadRequest();
                }
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

            var cashFlow = await _cashFlowService.GetByIdAsync(id.Value);
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
            await _cashFlowService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

