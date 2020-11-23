using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ItdevFinalProject.Data;
using ItdevFinalProject.Models;

namespace ItdevFinalProject.Controllers
{
    public class WorkInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WorkInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkInfo.ToListAsync());
        }

        // GET: WorkInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInfo = await _context.WorkInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workInfo == null)
            {
                return NotFound();
            }

            return View(workInfo);
        }

        // GET: WorkInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WorkInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorkLifeBalance,StockOptionLevel,TotalWorkingYears,EnvironmentSatisfaction,StandardHours,OverTime")] WorkInfo workInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workInfo);
        }

        // GET: WorkInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInfo = await _context.WorkInfo.FindAsync(id);
            if (workInfo == null)
            {
                return NotFound();
            }
            return View(workInfo);
        }

        // POST: WorkInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorkLifeBalance,StockOptionLevel,TotalWorkingYears,EnvironmentSatisfaction,StandardHours,OverTime")] WorkInfo workInfo)
        {
            if (id != workInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkInfoExists(workInfo.Id))
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
            return View(workInfo);
        }

        // GET: WorkInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workInfo = await _context.WorkInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workInfo == null)
            {
                return NotFound();
            }

            return View(workInfo);
        }

        // POST: WorkInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workInfo = await _context.WorkInfo.FindAsync(id);
            _context.WorkInfo.Remove(workInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkInfoExists(int id)
        {
            return _context.WorkInfo.Any(e => e.Id == id);
        }
    }
}
