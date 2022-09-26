using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // Retrieves all Zones
        public List<Zone> GetAll()
        {
            return _context.Zone.ToList();
        }

        // GET: Retrieves zone from specific ID
        public async Task<Zone> GetByID(Guid? id)
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);
            return (zone);
        }

        // POST: Creates a new zone entry
        public async Task<Zone> Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            _context.Add(zone);
            await _context.SaveChangesAsync();
            return (zone);
        }

        // GET: Edits a zone entry
        public async Task<Zone> Edit(Guid? id)
        {
            var zone = await _context.Zone.FindAsync(id);
            return (zone);
        }

        // POST: Edits a zone entry
        public async Task<Zone> Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone)
        {
            _context.Update(zone);
            await _context.SaveChangesAsync();
            return (zone);

        }

        // GET: Deletes a zone entry
        public async Task<Zone> Delete(Guid? id)
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);
            return (zone);
        }

        // POST: Confirms that a zone entry was deleted
        public async Task<Zone> DeleteConfirmed(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return (zone);
        }

        // Checks whether a zone entry exists
        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }
}
