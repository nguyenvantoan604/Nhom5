using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nhom05.Data;
using Nhom05.Models;
using Nhom05.Models.Process;

namespace Nhom05.Controllers
{
    public class DanhGiaController : Controller
    {
        private readonly ApplicationDbContext _context;
        StringProcess dh = new StringProcess();

        public DanhGiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhGia
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DanhGia.Include(d => d.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DanhGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.IDDanhGia == id);
            if (danhGia == null)
            {
                return NotFound();
            }

            return View(danhGia);
        }

        // GET: DanhGia/Create
        public IActionResult Create()
        {
            var newID ="";
            if(_context.DanhGia.Count()==0){
                newID ="DG01";
            }else{
                var IDdg = _context.DanhGia.OrderByDescending(x => x.IDDanhGia).First().IDDanhGia;
                newID = dh.AutoGenerateKey(IDdg);
            }
            ViewBag.IDDanhGia = newID;

            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham");
            return View();
        }

        // POST: DanhGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDDanhGia,TenKhachHang,NoiDung,IDSanPham")] DanhGia danhGia)
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
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia.FindAsync(id);
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
        public async Task<IActionResult> Edit(string id, [Bind("IDDanhGia,TenKhachHang,NoiDung,IDSanPham")] DanhGia danhGia)
        {
            if (id != danhGia.IDDanhGia)
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
                    if (!DanhGiaExists(danhGia.IDDanhGia))
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
            if (id == null || _context.DanhGia == null)
            {
                return NotFound();
            }

            var danhGia = await _context.DanhGia
                .Include(d => d.SanPham)
                .FirstOrDefaultAsync(m => m.IDDanhGia == id);
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
            if (_context.DanhGia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhGia'  is null.");
            }
            var danhGia = await _context.DanhGia.FindAsync(id);
            if (danhGia != null)
            {
                _context.DanhGia.Remove(danhGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaExists(string id)
        {
          return (_context.DanhGia?.Any(e => e.IDDanhGia == id)).GetValueOrDefault();
        }
    }
}
