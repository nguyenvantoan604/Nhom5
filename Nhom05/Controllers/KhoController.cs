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
    public class KhoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public KhoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kho
        public async Task<IActionResult> Index()
        {
              return _context.Khos != null ? 
                          View(await _context.Khos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Khos'  is null.");
        }

        // GET: Kho/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Khos == null)
            {
                return NotFound();
            }

            var kho = await _context.Khos
                .FirstOrDefaultAsync(m => m.KhoID == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // GET: Kho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhoID,TenKho,TenSanPham,ThuongHieu,DiaChiKho")] Kho kho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kho);
        }

        // GET: Kho/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Khos == null)
            {
                return NotFound();
            }

            var kho = await _context.Khos.FindAsync(id);
            if (kho == null)
            {
                return NotFound();
            }
            return View(kho);
        }

        // POST: Kho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KhoID,TenKho,TenSanPham,ThuongHieu,DiaChiKho")] Kho kho)
        {
            if (id != kho.KhoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoExists(kho.KhoID))
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
            return View(kho);
        }

        // GET: Kho/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Khos == null)
            {
                return NotFound();
            }

            var kho = await _context.Khos
                .FirstOrDefaultAsync(m => m.KhoID == id);
            if (kho == null)
            {
                return NotFound();
            }

            return View(kho);
        }

        // POST: Kho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Khos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Khos'  is null.");
            }
            var kho = await _context.Khos.FindAsync(id);
            if (kho != null)
            {
                _context.Khos.Remove(kho);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoExists(string id)
        {
          return (_context.Khos?.Any(e => e.KhoID == id)).GetValueOrDefault();
        }
         public async Task<IActionResult> Upload(){
            return View();
        }
        [HttpPost]
          [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file){

            if(file != null){
                string fileExtension = Path.GetExtension(file.FileName);
                if(fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("","Please choose excel file to upload!");
                }
                else{
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);

                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for(int i = 0; i< dt.Rows.Count; i++)
                        {
                            var kh = new Kho();

                            kh.KhoID = dt.Rows[i][0].ToString();
                            kh.TenKho = dt.Rows[i][1].ToString();
                            kh.TenSanPham = dt.Rows[i][2].ToString();
                            kh.ThuongHieu = dt.Rows[i][3].ToString();
                            kh.DiaChiKho = dt.Rows[i][4].ToString();

                            _context.Khos.Add(kh);
                        } 

                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
