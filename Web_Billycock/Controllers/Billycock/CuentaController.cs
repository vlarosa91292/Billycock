using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Billycock.Data;
using Billycock.Models;

namespace Web_Billycock.Controllers
{
    public class CuentaController : Controller
    {
        private readonly BillycockServiceContext _context;

        public CuentaController(BillycockServiceContext context)
        {
            _context = context;
        }

        // GET: Cuenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.CUENTA.ToListAsync());
        }

        // GET: Cuenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.CUENTA
                .FirstOrDefaultAsync(m => m.idCuenta == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // GET: Cuenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCuenta,nombre,diminutivo,netflix,amazon,disney,hbo,youtube,spotify,descripcion,password,idEstado")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuenta);
        }

        // GET: Cuenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.CUENTA.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return View(cuenta);
        }

        // POST: Cuenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCuenta,nombre,diminutivo,netflix,amazon,disney,hbo,youtube,spotify,descripcion,password,idEstado")] Cuenta cuenta)
        {
            if (id != cuenta.idCuenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaExists(cuenta.idCuenta))
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
            return View(cuenta);
        }

        // GET: Cuenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.CUENTA
                .FirstOrDefaultAsync(m => m.idCuenta == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuenta = await _context.CUENTA.FindAsync(id);
            _context.CUENTA.Remove(cuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaExists(int id)
        {
            return _context.CUENTA.Any(e => e.idCuenta == id);
        }
    }
}
