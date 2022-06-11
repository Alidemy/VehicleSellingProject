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
    public class VehiclesController : Controller
    {
        private readonly VehicleContext _context;

        public VehiclesController(VehicleContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var vehicleContext = _context.Vehicles.Include(v => v.BodyType).Include(v => v.Door).Include(v => v.Cylinder).Include(v => v.EngineSize);
            return View(await vehicleContext.ToListAsync());
        }

        // GET: Vehicles/Add or Edit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "TypeName");
                ViewData["DoorId"] = new SelectList(_context.Doors, "Id", "Qty");
                ViewData["DoorId"] = new SelectList(_context.Cylinders, "Id", "Qty");
                ViewData["EngineSizeId"] = new SelectList(_context.EngineSizes, "Id", "Size");
                return View(new Vehicle());
            }
            else
            {
                ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "TypeName");
                ViewData["DoorId"] = new SelectList(_context.Doors, "Id", "Qty");
                ViewData["DoorId"] = new SelectList(_context.Cylinders, "Id", "Qty");
                ViewData["EngineSizeId"] = new SelectList(_context.EngineSizes, "Id", "Size");
                return View(_context.Vehicles.Find(id));
            }
            
        }

        // POST: Vehicles/Add or Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Brand,Name,Model,CostPrice,SellPrice,BodyTypeId,EngineSizeId,DoorId,CylinderId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vehicle.Id == 0)
                    _context.Add(vehicle);
                else
                    _context.Update(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BodyTypeId"] = new SelectList(_context.BodyTypes, "Id", "TypeName", vehicle.BodyTypeId);
            ViewData["DoorId"] = new SelectList(_context.Doors, "Id", "Qty", vehicle.DoorId);
            ViewData["DoorId"] = new SelectList(_context.Cylinders, "Id", "Qty", vehicle.CylinderId);
            ViewData["EngineSizeId"] = new SelectList(_context.EngineSizes, "Id", "Size", vehicle.EngineSizeId);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult GetEngineSizeBy(int bTypeId)
        {
            var data = _context.EngineSizes.Where(x => x.BodyTypeId == bTypeId).ToList();

            return Json(data);
        }

        public JsonResult GetDoorBy(int bTypeId)
        {
            var data = _context.Doors.Where(x => x.BodyTypeId == bTypeId).ToList();

            return Json(data);
        }
        public JsonResult GetCylinderBy(int bTypeId)
        {
            var data = _context.Cylinders.Where(x => x.BodyTypeId == bTypeId).ToList();

            return Json(data);
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
