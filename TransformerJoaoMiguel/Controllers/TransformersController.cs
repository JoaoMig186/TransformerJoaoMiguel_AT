using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using TransformerJoaoMiguel.Data;
using TransformerJoaoMiguel.Models;

namespace TransformerJoaoMiguel.Controllers
{
    public class TransformersController : Controller
    {
        private readonly TransformerJoaoMiguelContext _context;

        public TransformersController(TransformerJoaoMiguelContext context)
        {
            _context = context;
        }

        // GET: Transformers
        public async Task<IActionResult> Index()
        {
            var transformerJoaoMiguelContext = _context.Transformer.Include(t => t.TipoTransformer);
            return View(await transformerJoaoMiguelContext.ToListAsync());
        }

        // GET: Transformers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer = await _context.Transformer
                .Include(t => t.TipoTransformer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transformer == null)
            {
                return NotFound();
            }

            return View(transformer);
        }

        // GET: Transformers/Create
        public IActionResult Create()
        {
            ViewData["TipoTransformerId"] = new SelectList(_context.TipoTransformer, "Id", "Id");
            return View();
        }

        // POST: Transformers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transformer transformer)
        {
            if (ModelState.IsValid)
            {
                if (transformer.FotoUpload != null && transformer.FotoUpload.Length > 0)
                {
                    transformer.Imagem = UploadImage(transformer.FotoUpload);
                }
                _context.Add(transformer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoTransformerId"] = new SelectList(_context.TipoTransformer, "Id", "Id", transformer.TipoTransformerId);
            return View(transformer);
        }

        // GET: Transformers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer = await _context.Transformer.FindAsync(id);
            if (transformer == null)
            {
                return NotFound();
            }
            ViewData["TipoTransformerId"] = new SelectList(_context.TipoTransformer, "Id", "Id", transformer.TipoTransformerId);
            return View(transformer);
        }

        // POST: Transformers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transformer transformer)
        {
            if (id != transformer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (transformer.FotoUpload != null && transformer.FotoUpload.Length > 0)
                    {
                        DeleteImage(transformer.Imagem);

                        transformer.Imagem = UploadImage(transformer.FotoUpload);
                    }
                    _context.Update(transformer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransformerExists(transformer.Id))
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
            ViewData["TipoTransformerId"] = new SelectList(_context.TipoTransformer, "Id", "Id", transformer.TipoTransformerId);
            return View(transformer);
        }

        // GET: Transformers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transformer == null)
            {
                return NotFound();
            }

            var transformer = await _context.Transformer
                .Include(t => t.TipoTransformer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transformer == null)
            {
                return NotFound();
            }

            return View(transformer);
        }

        // POST: Transformers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transformer == null)
            {
                return Problem("Entity set 'TransformerJoaoMiguelContext.Transformer'  is null.");
            }
            var transformer = await _context.Transformer.FindAsync(id);
            if (transformer != null)
            {
                DeleteImage(transformer.Imagem);
                _context.Transformer.Remove(transformer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransformerExists(int id)
        {
          return (_context.Transformer?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string UploadImage(IFormFile file)
        {
            var nomeUnico = Guid.NewGuid().ToString() + "_" + file.FileName;
            var caminhoDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", nomeUnico);


            if (!Directory.Exists(Path.GetDirectoryName(caminhoDestino)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(caminhoDestino));
            }

            using (var stream = new FileStream(caminhoDestino, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return "/imagens/" + nomeUnico;
        }
        private void DeleteImage(string caminhoImagem)
        {
            if (!string.IsNullOrEmpty(caminhoImagem))
            {
                var caminhoCompleto = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", caminhoImagem.TrimStart('/'));
                if (System.IO.File.Exists(caminhoCompleto))
                {
                    System.IO.File.Delete(caminhoCompleto);
                }
            }
        }
    }
}
