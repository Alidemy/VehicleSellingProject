using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleSellingProject.WebApplication.Models;
using VehicleSellingProject.WebApplication.Utility;

namespace VehicleSellingProject.WebApplication.Controllers
{
    public class SellingInfoesController : Controller
    {
        private readonly VehicleContext _context;

        public SellingInfoesController(VehicleContext context)
        {
            _context = context;
        }

        // GET: SellingInfoes
        public async Task<IActionResult> Index()
        {
            var vehicleContext = _context.SellingInfos.Include(s => s.SellingBranch).Include(s => s.Vehicle).Include(s => s.Vehicle.BodyType);
            return View(await vehicleContext.ToListAsync());
        }

        // GET: SellingInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingInfo = await _context.SellingInfos
                .Include(s => s.SellingBranch)
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingInfo == null)
            {
                return NotFound();
            }

            return View(sellingInfo);
        }

        // GET: SellingInfoes/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.SellingBranches, "Id", "BAddress");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Name");
            return View();
        }

        // POST: SellingInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,BranchId,BuyerName,BuyerTel")] SellingInfo sellingInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sellingInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.SellingBranches, "Id", "BAddress", sellingInfo.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Name", sellingInfo.VehicleId);
            return View(sellingInfo);
        }

        // GET: SellingInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingInfo = await _context.SellingInfos.FindAsync(id);
            if (sellingInfo == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.SellingBranches, "Id", "BAddress", sellingInfo.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Name", sellingInfo.VehicleId);
            return View(sellingInfo);
        }

        // POST: SellingInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,BranchId,BuyerName,BuyerTel")] SellingInfo sellingInfo)
        {
            if (id != sellingInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellingInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellingInfoExists(sellingInfo.Id))
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
            ViewData["BranchId"] = new SelectList(_context.SellingBranches, "Id", "BAddress", sellingInfo.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Name", sellingInfo.VehicleId);
            return View(sellingInfo);
        }

        // GET: SellingInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellingInfo = await _context.SellingInfos
                .Include(s => s.SellingBranch)
                .Include(s => s.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sellingInfo == null)
            {
                return NotFound();
            }

            return View(sellingInfo);
        }

        // POST: SellingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellingInfo = await _context.SellingInfos.FindAsync(id);
            _context.SellingInfos.Remove(sellingInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Report()
        {
            var vehicleContext = _context.SellingInfos
                                 .Include(s => s.SellingBranch)
                                 .Include(s => s.Vehicle.BodyType)
                                 .Include(s => s.Vehicle);
            var VCQuery = //vehicleContext.Sum(s => s.Vehicle.SellPrice);
                          vehicleContext.Where(s => s.Vehicle.BodyTypeId == 1).ToList();
                          /*vehicleContext.GroupBy(s => s.Vehicle.BodyTypeId)
                                      .Select(lg =>
                                       new {
                                              Type = lg.Key,
                                              Count = lg.Count(),
                                              TotalSelling = lg.Sum(t => t.Vehicle.SellPrice)
                                            }.ToExpando());*/
            return View(VCQuery);
        }


        private bool SellingInfoExists(int id)
        {
            return _context.SellingInfos.Any(e => e.Id == id);
        }
    }
}
