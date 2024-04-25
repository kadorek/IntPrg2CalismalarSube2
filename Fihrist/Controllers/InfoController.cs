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
    public class InfoController : Controller
    {
        private readonly Fihrist2Context _context;

        public InfoController()
        {
            _context = new();
        }

        // GET: Info
        public async Task<IActionResult> Index()
        {
            var fihrist2Context = _context.Infos.Include(i => i.Person).Include(i => i.Type);
            return View(await fihrist2Context.ToListAsync());
        }

        // GET: Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .Include(i => i.Person)
                .Include(i => i.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // GET: Info/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Fullname");
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Name");
            return View();
        }

        // POST: Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,TypeId,Value")] Info info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", info.PersonId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", info.TypeId);
            return View(info);
        }

        // GET: Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos.FindAsync(id);
            if (info == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", info.PersonId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", info.TypeId);
            return View(info);
        }

        // POST: Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,TypeId,Value")] Info info)
        {
            if (id != info.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoExists(info.Id))
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
            ViewData["PersonId"] = new SelectList(_context.People, "Id", "Id", info.PersonId);
            ViewData["TypeId"] = new SelectList(_context.Types, "Id", "Id", info.TypeId);
            return View(info);
        }

        // GET: Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var info = await _context.Infos
                .Include(i => i.Person)
                .Include(i => i.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (info == null)
            {
                return NotFound();
            }

            return View(info);
        }

        // POST: Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var info = await _context.Infos.FindAsync(id);
            if (info != null)
            {
                _context.Infos.Remove(info);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoExists(int id)
        {
            return _context.Infos.Any(e => e.Id == id);
        }
    }
}
