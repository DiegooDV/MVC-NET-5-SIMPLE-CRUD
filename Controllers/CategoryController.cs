using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_NET_5.Data;
using MVC_NET_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_NET_5.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _db.Categories.ToListAsync();
            return await Task.Run(() => View(categories));
        }

        //CREATE GET - RETURN VIEW
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        //CREATE POST - REDIRECT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        //EDIT GET - RETURN VIEW
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return await Task.Run(() => View(category));
        }

        //EDIT POST - REDIRECT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        //DELETE GET - RETURN VIEW
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return await Task.Run(() => View(category));
        }

        //DELETE POST - REDIRECT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int id)
        {
            var category = await _db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
