using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFTestingAPP.Data;
using EFTestingAPP.Models;

namespace EFTestingAPP.Controllers
{
    public class ClientController : Controller
    {
        private readonly EFTestingAPPContext _context;

        public ClientController(EFTestingAPPContext context)
        {
            _context = context;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientModels.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModelcs = await _context.ClientModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModelcs == null)
            {
                return NotFound();
            }

            return View(clientModelcs);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DOB")] ClientModelcs clientModelcs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientModelcs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientModelcs);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModelcs = await _context.ClientModels.FindAsync(id);
            if (clientModelcs == null)
            {
                return NotFound();
            }
            return View(clientModelcs);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DOB")] ClientModelcs clientModelcs)
        {
            if (id != clientModelcs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientModelcs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientModelcsExists(clientModelcs.Id))
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
            return View(clientModelcs);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientModelcs = await _context.ClientModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientModelcs == null)
            {
                return NotFound();
            }

            return View(clientModelcs);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientModelcs = await _context.ClientModels.FindAsync(id);
            if (clientModelcs != null)
            {
                _context.ClientModels.Remove(clientModelcs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientModelcsExists(int id)
        {
            return _context.ClientModels.Any(e => e.Id == id);
        }
    }
}
