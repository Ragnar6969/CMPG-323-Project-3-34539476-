using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository
    {

        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // Returns all category entries
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        // Returns the category entry from specific ID
        public async Task<Category> GetByID(Guid? id)
        {

            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);

            return (category);
        }

        // Adds a new category entry
        public async Task<Category> Insert([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return (entity);
        }

        // Changes category entry from specific ID
        public async Task<Category> Update(Guid? id)
        {
            var category = await _context.Category.FindAsync(id);
            return (category);
        }
        // Changes category entry from specific ID
        public async Task<Category> Update(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {

            _context.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Deletes a category entry
        public async Task<Category> Remove(Guid? id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);
            return (category);
        }

        // Confirms the remove of a category entry
        public async Task<Category> RemoveConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        //Checks if a category antry exists from a specific ID
        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
