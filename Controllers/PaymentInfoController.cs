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
    public class PaymentInfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaymentInfo
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentInfo.ToListAsync());
        }

        // GET: PaymentInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentInfo == null)
            {
                return NotFound();
            }

            return View(paymentInfo);
        }

        // GET: PaymentInfo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,EmployeeNumber,MonthlyIncome,MonthlyRate,PerformanceRating,PercentSalaryHike")] PaymentInfo paymentInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentInfo);
        }

        // GET: PaymentInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo.FindAsync(id);
            if (paymentInfo == null)
            {
                return NotFound();
            }
            return View(paymentInfo);
        }

        // POST: PaymentInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,EmployeeNumber,MonthlyIncome,MonthlyRate,PerformanceRating,PercentSalaryHike")] PaymentInfo paymentInfo)
        {
            if (id != paymentInfo.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentInfoExists(paymentInfo.PaymentId))
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
            return View(paymentInfo);
        }

        // GET: PaymentInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentInfo = await _context.PaymentInfo
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentInfo == null)
            {
                return NotFound();
            }

            return View(paymentInfo);
        }

        // POST: PaymentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentInfo = await _context.PaymentInfo.FindAsync(id);
            _context.PaymentInfo.Remove(paymentInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentInfoExists(int id)
        {
            return _context.PaymentInfo.Any(e => e.PaymentId == id);
        }
    }
}
