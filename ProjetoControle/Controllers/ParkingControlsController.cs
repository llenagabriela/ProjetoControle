using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoControle.Data;
using ProjetoControle.Models;

namespace ProjetoControle.Controllers
{
    public class ParkingControlsController : Controller
    {
        private readonly ProjetoControleContext _context;

        public ParkingControlsController(ProjetoControleContext context)
        {
            _context = context;
        }

        // GET: ParkingControls
        public async Task<IActionResult> Index()
        {
              return _context.ParkingControl != null ? 
                          View(await _context.ParkingControl.ToListAsync()) :
                          Problem("Entity set 'ProjetoControleContext.ParkingControl'  is null.");
        }

        // GET: ParkingControls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingControl == null)
            {
                return NotFound();
            }

            var parkingControl = await _context.ParkingControl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingControl == null)
            {
                return NotFound();
            }

            return View(parkingControl);
        }

        // GET: ParkingControls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingControls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa,DataEnt,DataSai,TimeEnt,TimeSai,Duracao,TimeCobr,Preco,ValorPag")] ParkingControl parkingControl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingControl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingControl);
        }

        // GET: ParkingControls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingControl == null)
            {
                return NotFound();
            }

            var parkingControl = await _context.ParkingControl.FindAsync(id);
            if (parkingControl == null)
            {
                return NotFound();
            }
            return View(parkingControl);
        }

        // POST: ParkingControls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,DataEnt,DataSai,TimeEnt,TimeSai,Duracao,TimeCobr,Preco,ValorPag")] ParkingControl parkingControl)
        {
            if (id != parkingControl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingControl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingControlExists(parkingControl.Id))
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
            return View(parkingControl);
        }

        // GET: ParkingControls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingControl == null)
            {
                return NotFound();
            }

            var parkingControl = await _context.ParkingControl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingControl == null)
            {
                return NotFound();
            }

            return View(parkingControl);
        }

        // POST: ParkingControls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingControl == null)
            {
                return Problem("Entity set 'ProjetoControleContext.ParkingControl'  is null.");
            }
            var parkingControl = await _context.ParkingControl.FindAsync(id);
            if (parkingControl != null)
            {
                _context.ParkingControl.Remove(parkingControl);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingControlExists(int id)
        {
          return (_context.ParkingControl?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
