using DeviceManagement_WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        // This retrieves the most recent category
        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(Category => Category.DateCreated).FirstOrDefault();
        }

        // this checks if an entry exists
        public bool Exists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
