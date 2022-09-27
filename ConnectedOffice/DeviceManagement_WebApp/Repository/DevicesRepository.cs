using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        // This retrieves the most recent device
        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        //This creates a list for categories
        public SelectList showCat()
        {
            SelectList cat = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return cat;
        }

        //This creates a list for zones
        public SelectList showZone()
        {
            SelectList zone = new SelectList(_context.Zone, "ZoneId", "ZoneName");
            return zone;
        }

        //This creates a list for categories based on a specific id
        public SelectList editCat(Guid? id)
        {
            var device = this.GetById(id);
            SelectList cat = new SelectList(_context.Category, "CategoryId", "CategoryName", device.CategoryId);
            return cat;
        }

        //This creates a list for zones based on a specific id
        public SelectList editZone(Guid? id)
        {
            var device = this.GetById(id);
            SelectList zone = new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);
            return zone;
        }

        // this checks if an entry exists
        public bool Exists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

    }
}
