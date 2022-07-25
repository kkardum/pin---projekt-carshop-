using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    public class autiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public autiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: auti
        public async Task<IActionResult> Index(string search)
        {
            ViewBag.Search = search;
            if (!String.IsNullOrEmpty(search))
            {
                var auti = from auto in _context.auto
                           select auto;

                auti = auti.Where(auto => auto.marka.Contains(search));

                return View(auti.ToList());
            }
            return View(await _context.auto.ToListAsync());
        }

        // GET: auti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.auto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auti == null)
            {
                return NotFound();
            }

            return View(auti);
        }

        // GET: auti/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: auti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,marka,model,god_proizvodnje")] auti auti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auti);
        }

        // GET: auti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.auto.FindAsync(id);
            if (auti == null)
            {
                return NotFound();
            }
            return View(auti);
        }

        // POST: auti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,marka,model,god_proizvodnje")] auti auti)
        {
            if (id != auti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!autiExists(auti.Id))
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
            return View(auti);
        }

        // GET: auti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auti = await _context.auto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auti == null)
            {
                return NotFound();
            }

            return View(auti);
        }

        // POST: auti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auti = await _context.auto.FindAsync(id);
            _context.auto.Remove(auti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool autiExists(int id)
        {
            return _context.auto.Any(e => e.Id == id);
        }
    }
}
