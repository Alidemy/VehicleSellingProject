using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleSellingProject.WebApplication.Models;

namespace VehicleSellingProject.WebApplication.Controllers
{
    public class SellingBranchesController : Controller
    {
        private readonly VehicleContext _context;

        public SellingBranchesController(VehicleContext context)
        {
            _context = context;
        }

        // GET: SellingBranches
        public async Task<IActionResult> Index()
        {
            return View(await _context.SellingBranches.ToListAsync());
        }

        // GET: SellingBranches/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingBranch = await _context.SellingBranches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingBranch == null)
            {
                return NotFound();
            }

            return View(sellingBranch);
        }

        // GET: SellingBranches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SellingBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BNumber,BName,BAddress,BTel")] SellingBranch sellingBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellingBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sellingBranch);
        }

        // GET: SellingBranches/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingBranch = await _context.SellingBranches.FindAsync(id);
            if (sellingBranch == null)
            {
                return NotFound();
            }
            return View(sellingBranch);
        }

        // POST: SellingBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,BNumber,BName,BAddress,BTel")] SellingBranch sellingBranch)
        {
            if (id != sellingBranch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellingBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellingBranchExists(sellingBranch.Id))
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
            return View(sellingBranch);
        }

        // GET: SellingBranches/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingBranch = await _context.SellingBranches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingBranch == null)
            {
                return NotFound();
            }

            return View(sellingBranch);
        }

        // POST: SellingBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var sellingBranch = await _context.SellingBranches.FindAsync(id);
            _context.SellingBranches.Remove(sellingBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellingBranchExists(byte id)
        {
            return _context.SellingBranches.Any(e => e.Id == id);
        }
    }
}
