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
    public class EmployeeInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeInfo.ToListAsync());
        }

        // GET: EmployeeInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfo
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // GET: EmployeeInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumber,Age,Over18,RelationshipSatisfaction")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeInfo);
        }

        // GET: EmployeeInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }
            return View(employeeInfo);
        }

        // POST: EmployeeInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumber,Age,Over18,RelationshipSatisfaction")] EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInfoExists(employeeInfo.EmployeeNumber))
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
            return View(employeeInfo);
        }

        // GET: EmployeeInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeInfo = await _context.EmployeeInfo
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        // POST: EmployeeInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeInfo = await _context.EmployeeInfo.FindAsync(id);
            _context.EmployeeInfo.Remove(employeeInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInfoExists(int id)
        {
            return _context.EmployeeInfo.Any(e => e.EmployeeNumber == id);
        }
    }
}
