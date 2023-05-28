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
    public class HoaDonController : Controller
    {
        private readonly ApplicationDbContext _context;
        StringProcess hd = new StringProcess();

        public HoaDonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDon
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HoaDons.Include(h => h.KhachHang).Include(h => h.NhanVien).Include(h => h.SanPham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HoaDon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IDHoaDon == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDon/Create
        public IActionResult Create()
        {
            var newID = "";
            if(_context.HoaDons.Count()==0){
                 newID ="HD01";
            }else{
                var IDhd = _context.HoaDons.OrderByDescending(h =>h.IDHoaDon).First().IDHoaDon;
                newID = hd.AutoGenerateKey(IDhd);
            }
            ViewBag.IDHoaDon = newID;
            ViewData["IDKhachHang"] = new SelectList(_context.KhachHangs, "IDKhachHang", "TenKhachHang");
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "TenNhanVien");
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham");
            return View();
        }

        // POST: HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDHoaDon,IDKhachHang,IDSanPham,DiaChi,STD,TongGia,IDNhanVien")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDKhachHang"] = new SelectList(_context.KhachHangs, "IDKhachHang", "TenKhachHang", hoaDon.IDKhachHang);
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "TenNhanVien", hoaDon.IDNhanVien);
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", hoaDon.IDSanPham);
            return View(hoaDon);
        }

        // GET: HoaDon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["IDKhachHang"] = new SelectList(_context.KhachHangs, "IDKhachHang", "TenKhachHang", hoaDon.IDKhachHang);
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "TenNhanVien", hoaDon.IDNhanVien);
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", hoaDon.IDSanPham);
            return View(hoaDon);
        }

        // POST: HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDHoaDon,IDKhachHang,IDSanPham,DiaChi,STD,TongGia,IDNhanVien")] HoaDon hoaDon)
        {
            if (id != hoaDon.IDHoaDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.IDHoaDon))
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
            ViewData["IDKhachHang"] = new SelectList(_context.KhachHangs, "IDKhachHang", "TenKhachHang", hoaDon.IDKhachHang);
            ViewData["IDNhanVien"] = new SelectList(_context.NhanVien, "IDNhanVien", "TenNhanVien", hoaDon.IDNhanVien);
            ViewData["IDSanPham"] = new SelectList(_context.SanPhams, "IDSanPham", "TenSanPham", hoaDon.IDSanPham);
            return View(hoaDon);
        }

        // GET: HoaDon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.KhachHang)
                .Include(h => h.NhanVien)
                .Include(h => h.SanPham)
                .FirstOrDefaultAsync(m => m.IDHoaDon == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDons == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HoaDons'  is null.");
            }
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDons.Remove(hoaDon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(string id)
        {
          return (_context.HoaDons?.Any(e => e.IDHoaDon == id)).GetValueOrDefault();
        }
    }
}
