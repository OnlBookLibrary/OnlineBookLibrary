using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBookLibrary.Models;

namespace OnlineBookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStaffsController : Controller
    {
        private readonly OnlineBookLibraryDataContext _context;

        public AdminStaffsController(OnlineBookLibraryDataContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminStaffs
        public async Task<IActionResult> Index()
        {
            var onlineBookLibraryDataContext = _context.AdminStaffs.Include(a => a.Role);
            return View(await onlineBookLibraryDataContext.ToListAsync());
        }

        // GET: Admin/AdminStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminStaffs == null)
            {
                return NotFound();
            }

            var adminStaff = await _context.AdminStaffs
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (adminStaff == null)
            {
                return NotFound();
            }

            return View(adminStaff);
        }

        // GET: Admin/AdminStaffs/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View();
        }

        // POST: Admin/AdminStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Phone,Email,Password,FullName,RoleId")] AdminStaff adminStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", adminStaff.RoleId);
            return View(adminStaff);
        }

        // GET: Admin/AdminStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminStaffs == null)
            {
                return NotFound();
            }

            var adminStaff = await _context.AdminStaffs.FindAsync(id);
            if (adminStaff == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", adminStaff.RoleId);
            return View(adminStaff);
        }

        // POST: Admin/AdminStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Phone,Email,Password,FullName,RoleId")] AdminStaff adminStaff)
        {
            if (id != adminStaff.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminStaffExists(adminStaff.AccountId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", adminStaff.RoleId);
            return View(adminStaff);
        }

        // GET: Admin/AdminStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminStaffs == null)
            {
                return NotFound();
            }

            var adminStaff = await _context.AdminStaffs
                .Include(a => a.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (adminStaff == null)
            {
                return NotFound();
            }

            return View(adminStaff);
        }

        // POST: Admin/AdminStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminStaffs == null)
            {
                return Problem("Entity set 'OnlineBookLibraryDataContext.AdminStaffs'  is null.");
            }
            var adminStaff = await _context.AdminStaffs.FindAsync(id);
            if (adminStaff != null)
            {
                _context.AdminStaffs.Remove(adminStaff);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminStaffExists(int id)
        {
          return (_context.AdminStaffs?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
