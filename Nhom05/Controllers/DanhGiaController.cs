using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom05.Data;
using Nhom05.Models;

namespace Nhom05.Controllers
{
    public class DanhGiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhGiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhGia
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DanhGias.Include(d => d.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DanhGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhGias == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGias
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.TenKhachHang == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // GET: DanhGia/Create
        public IActionResult Create()
        {
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham");
            return View();
        }

        // POST: DanhGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenKhachHang,NoiDung,IDSanPham")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", danhGia.IDSanPham);
            return View(danhGia);
        }

        // GET: DanhGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DanhGias == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGias.FindAsync(id);
            if (danhGia == null)
            {
                return NotFound();
            }
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", danhGia.IDSanPham);
            return View(danhGia);
        }

        // POST: DanhGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TenKhachHang,NoiDung,IDSanPham")] DanhGia danhGia)
        {
            if (id != danhGia.TenKhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaExists(danhGia.TenKhachHang))
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
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", danhGia.IDSanPham);
            return View(danhGia);
        }

        // GET: DanhGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DanhGias == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGias
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.TenKhachHang == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // POST: DanhGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DanhGias == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhGias'  is null.");
            }
            var danhGia = await _context.DanhGias.FindAsync(id);
            if (danhGia != null)
            {
                _context.DanhGias.Remove(danhGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaExists(string id)
        {
          return (_context.DanhGias?.Any(e => e.TenKhachHang == id)).GetValueOrDefault();
        }
    }
}
