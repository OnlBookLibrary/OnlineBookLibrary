using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;
using PagedList.Core;

namespace OnlineBookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly OnlineBookLibraryDataContext _context;
        private INotyfService _notifyService;
        private IWebHostEnvironment _hostEnvironment;

        public IWebHostEnvironment HostEnviroment { get; }

        public BooksController(OnlineBookLibraryDataContext context, INotyfService notifyService, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _notifyService = notifyService;
            this._hostEnvironment = hostEnviroment;

        }

        // GET: Admin/Books
        public IActionResult Index(string searchString, int page = 1, int GenreID = 0)
        {
            List<SelectListItem> IsTrangThai = new List<SelectListItem>();
            IsTrangThai.Add(new SelectListItem() { Text = "Available", Value = "1" });
            IsTrangThai.Add(new SelectListItem() { Text = "Out of stock", Value = "0" });
            ViewData["IsTrangThai"] = IsTrangThai;

            var books = from b in _context.Books
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title!.Contains(searchString));
            }


            var pageNumber = page;
            var pageSize = 5;

            List<Book> IsBooks = new List<Book>();

            if (GenreID != 0)
            {
                IsBooks = _context.Books
                .AsNoTracking()
                .Where(b => b.GenreId == GenreID)
                .Include(b => b.Genre)
                .OrderByDescending(b => b.Id).ToList();
            }
            else
            {
                IsBooks = _context.Books
                    .AsNoTracking()
                    .Include(b => b.Genre)
                    .OrderByDescending(x => x.Id).ToList();

            }

            PagedList<Book> models = new PagedList<Book>(IsBooks.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentGenreID = GenreID;
            ViewBag.CurrentPage = pageNumber;
            ViewData["TheLoai"] = new SelectList(_context.Genres, "Id", "Name", GenreID);
            return View(models);
        }

        public IActionResult Filtter(int GenreID = 0)
        {
            var url = $"/Amin/Books?GenreID = {GenreID}";
            if (GenreID == 0)
            {
                url = $"/Admin/Books";
            }

            return Json(new { status = "success", redirectUrl = url });
        }

        // GET: Admin/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Admin/Books/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Description,Image,ImageFile,Price,Status,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRoothPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(path: book.ImageFile.FileName);
                string extension = Path.GetExtension(path: book.ImageFile.FileName);
                book.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRoothPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create)) { await book.ImageFile.CopyToAsync(fileStream); }
                //Insert record
                _context.Add(book);
                await _context.SaveChangesAsync();
                _notifyService.Success("Create successfully");
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", book.GenreId);
            return View(book);
        }

        // GET: Admin/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", book.Image);
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", book.GenreId);
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Description,ImageFile,Price,Status,GenreId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                _notifyService.Success("Edit successfully");
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", book.GenreId);
            return View(book);
        }

        // GET: Admin/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'OnlineBookLibraryDataContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            //delete image form wwwroot
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", book.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            _notifyService.Success("Delete successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
