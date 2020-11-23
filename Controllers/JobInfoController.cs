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
    public class JobInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobInfo.ToListAsync());
        }

        // GET: JobInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // GET: JobInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeNumber,JobInvolvement,JobLevel,JobRole,JobSatisfaction,BusinessTravel")] JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobInfo);
        }

        // GET: JobInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo.FindAsync(id);
            if (jobInfo == null)
            {
                return NotFound();
            }
            return View(jobInfo);
        }

        // POST: JobInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeNumber,JobInvolvement,JobLevel,JobRole,JobSatisfaction,BusinessTravel")] JobInfo jobInfo)
        {
            if (id != jobInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobInfoExists(jobInfo.Id))
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
            return View(jobInfo);
        }

        // GET: JobInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // POST: JobInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobInfo = await _context.JobInfo.FindAsync(id);
            _context.JobInfo.Remove(jobInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobInfoExists(int id)
        {
            return _context.JobInfo.Any(e => e.Id == id);
        }
    }
}
