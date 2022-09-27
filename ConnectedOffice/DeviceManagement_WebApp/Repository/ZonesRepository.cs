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
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        // This retrieves the most recent Zone
        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(Device => Device.DateCreated).FirstOrDefault();
        }

        // this checks if an entry exists
        public bool Exists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

    }
}
