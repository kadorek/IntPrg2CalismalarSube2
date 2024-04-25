using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fihrist.Models;

namespace Fihrist.Controllers
{
    public class TypeController : Controller
    {
        private readonly Fihrist2Context _context;

        public TypeController()
        {
            _context = new Fihrist2Context();
        }

        // GET: Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Types.ToListAsync());
        }

        // GET: Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // GET: Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Fihrist.Models.Type @type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@type);
        }

        // GET: Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Types.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }
            return View(@type);
        }

        // POST: Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Fihrist.Models.Type @type)
        {
            if (id != @type.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExists(@type.Id))
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
            return View(@type);
        }

        // GET: Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @type = await _context.Types
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@type == null)
            {
                return NotFound();
            }

            return View(@type);
        }

        // POST: Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @type = await _context.Types.FindAsync(id);
            if (@type != null)
            {
                _context.Types.Remove(@type);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
