using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dreams.Web.Data;
using Dreams.Web.Data.Entities;

namespace Dreams.Web.Controllers
{
    public class UnitEntitiesController : Controller
    {
        private readonly DataContext _context;

        public UnitEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: UnitEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Units.ToListAsync());
        }

        // GET: UnitEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitEntity == null)
            {
                return NotFound();
            }

            return View(unitEntity);
        }

        // GET: UnitEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Descripcion,CreateDate,UpdateDate")] UnitEntity unitEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitEntity);
        }

        // GET: UnitEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.Units.FindAsync(id);
            if (unitEntity == null)
            {
                return NotFound();
            }
            return View(unitEntity);
        }

        // POST: UnitEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Descripcion,CreateDate,UpdateDate")] UnitEntity unitEntity)
        {
            if (id != unitEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitEntityExists(unitEntity.Id))
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
            return View(unitEntity);
        }

        // GET: UnitEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitEntity = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitEntity == null)
            {
                return NotFound();
            }

            return View(unitEntity);
        }

        // POST: UnitEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitEntity = await _context.Units.FindAsync(id);
            _context.Units.Remove(unitEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitEntityExists(int id)
        {
            return _context.Units.Any(e => e.Id == id);
        }
    }
}
