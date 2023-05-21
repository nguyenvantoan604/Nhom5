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
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        StringProcess kh = new StringProcess();

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KhachHang
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhachHangs.Include(k => k.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KhachHangs == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .Include(k => k.SanPham)
                .FirstOrDefaultAsync(m => m.IDKhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            var newID = "";
            if(_context.KhachHangs.Count() ==0){
                newID = "KH001";
            }else{
                var IDKH = _context.KhachHangs.OrderByDescending(x => x.IDKhachHang).First().IDKhachHang;
                newID = kh.AutoGenerateKey(IDKH);
            }
            ViewBag.IDKhachHang = newID;
            
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham");
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDKhachHang,TenKhachHang,STD,DiaChi,IDSanPham")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", khachHang.IDSanPham);
            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KhachHangs == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", khachHang.IDSanPham);
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDKhachHang,TenKhachHang,STD,DiaChi,IDSanPham")] KhachHang khachHang)
        {
            if (id != khachHang.IDKhachHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.IDKhachHang))
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
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", khachHang.IDSanPham);
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KhachHangs == null)
            {
                return NotFound();
            }

            var khachHang = await _context.KhachHangs
                .Include(k => k.SanPham)
                .FirstOrDefaultAsync(m => m.IDKhachHang == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KhachHangs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KhachHangs'  is null.");
            }
            var khachHang = await _context.KhachHangs.FindAsync(id);
            if (khachHang != null)
            {
                _context.KhachHangs.Remove(khachHang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(string id)
        {
          return (_context.KhachHangs?.Any(e => e.IDKhachHang == id)).GetValueOrDefault();
        }
    }
}
