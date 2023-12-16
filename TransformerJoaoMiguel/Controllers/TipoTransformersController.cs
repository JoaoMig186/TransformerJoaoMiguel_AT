using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransformerJoaoMiguel.Data;
using TransformerJoaoMiguel.Models;

namespace TransformerJoaoMiguel.Controllers
{
    public class TipoTransformersController : Controller
    {
        private readonly TransformerJoaoMiguelContext _context;

        public TipoTransformersController(TransformerJoaoMiguelContext context)
        {
            _context = context;
        }

        // GET: TipoTransformers
        public async Task<IActionResult> Index()
        {
              return _context.TipoTransformer != null ? 
                          View(await _context.TipoTransformer.ToListAsync()) :
                          Problem("Entity set 'TransformerJoaoMiguelContext.TipoTransformer'  is null.");
        }

        // GET: TipoTransformers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoTransformer == null)
            {
                return NotFound();
            }

            var tipoTransformer = await _context.TipoTransformer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTransformer == null)
            {
                return NotFound();
            }

            return View(tipoTransformer);
        }

        // GET: TipoTransformers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTransformers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] TipoTransformer tipoTransformer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoTransformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTransformer);
        }

        // GET: TipoTransformers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoTransformer == null)
            {
                return NotFound();
            }

            var tipoTransformer = await _context.TipoTransformer.FindAsync(id);
            if (tipoTransformer == null)
            {
                return NotFound();
            }
            return View(tipoTransformer);
        }

        // POST: TipoTransformers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] TipoTransformer tipoTransformer)
        {
            if (id != tipoTransformer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTransformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTransformerExists(tipoTransformer.Id))
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
            return View(tipoTransformer);
        }

        // GET: TipoTransformers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoTransformer == null)
            {
                return NotFound();
            }

            var tipoTransformer = await _context.TipoTransformer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTransformer == null)
            {
                return NotFound();
            }

            return View(tipoTransformer);
        }

        // POST: TipoTransformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoTransformer == null)
            {
                return Problem("Entity set 'TransformerJoaoMiguelContext.TipoTransformer'  is null.");
            }
            var tipoTransformer = await _context.TipoTransformer.FindAsync(id);
            if (tipoTransformer != null)
            {
                _context.TipoTransformer.Remove(tipoTransformer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTransformerExists(int id)
        {
          return (_context.TipoTransformer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
