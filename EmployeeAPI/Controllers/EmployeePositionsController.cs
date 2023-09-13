using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    public class EmployeePositionsController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeePositionsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: EmployeePositions
        public async Task<IActionResult> Index()
        {
              return _context.EmployeePositions != null ? 
                          View(await _context.EmployeePositions.ToListAsync()) :
                          Problem("Entity set 'EmployeeContext.EmployeePositions'  is null.");
        }

        // GET: EmployeePositions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EmployeePositions == null)
            {
                return NotFound();
            }

            var employeePosition = await _context.EmployeePositions
                .FirstOrDefaultAsync(m => m.EmpID == id);
            if (employeePosition == null)
            {
                return NotFound();
            }

            return View(employeePosition);
        }

        // GET: EmployeePositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeePositions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpID,EmpPosition,DateOfJoining,Salary")] EmployeePosition employeePosition)
        {
            if (ModelState.IsValid)
            {
                employeePosition.EmpID = Guid.NewGuid();
                _context.Add(employeePosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePosition);
        }

        // GET: EmployeePositions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EmployeePositions == null)
            {
                return NotFound();
            }

            var employeePosition = await _context.EmployeePositions.FindAsync(id);
            if (employeePosition == null)
            {
                return NotFound();
            }
            return View(employeePosition);
        }

        // POST: EmployeePositions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmpID,EmpPosition,DateOfJoining,Salary")] EmployeePosition employeePosition)
        {
            if (id != employeePosition.EmpID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePositionExists(employeePosition.EmpID))
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
            return View(employeePosition);
        }

        // GET: EmployeePositions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EmployeePositions == null)
            {
                return NotFound();
            }

            var employeePosition = await _context.EmployeePositions
                .FirstOrDefaultAsync(m => m.EmpID == id);
            if (employeePosition == null)
            {
                return NotFound();
            }

            return View(employeePosition);
        }

        // POST: EmployeePositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EmployeePositions == null)
            {
                return Problem("Entity set 'EmployeeContext.EmployeePositions'  is null.");
            }
            var employeePosition = await _context.EmployeePositions.FindAsync(id);
            if (employeePosition != null)
            {
                _context.EmployeePositions.Remove(employeePosition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePositionExists(Guid id)
        {
          return (_context.EmployeePositions?.Any(e => e.EmpID == id)).GetValueOrDefault();
        }
    }
}
