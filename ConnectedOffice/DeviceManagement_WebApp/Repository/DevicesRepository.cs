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
    public class DevicesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        // Retrieves all devices
        public List<Device> GetAll()
        {            
            return _context.Device.ToList(); ;
        }

        // GET: Retrieves device from specific ID
        public async Task<Device> GetByID(Guid? id)
        {
            var device = await _context.Device.Include(d => d.Category).Include(d => d.Zone).FirstOrDefaultAsync(m => m.DeviceId == id);

            return (device);
        }

        // POST: Creates a new device entry
        public async Task<Device> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            _context.Add(device);
            await _context.SaveChangesAsync();
            return (device);
        }

        // GET: Edits a device entry
        public async Task<Device> Edit(Guid? id)
        {
            var device = await _context.Device.FindAsync(id);
            return (device);
        }

        // POST: Edits a device entry
        public async Task<Device> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {

            _context.Update(device);
            await _context.SaveChangesAsync();

            return (device);

        }

        // GET: Deletes a device entry
        public async Task<Device> Delete(Guid? id)
        {

            var device = await _context.Device.Include(d => d.Category).Include(d => d.Zone).FirstOrDefaultAsync(m => m.DeviceId == id);

            return (device);
        }

        // POST: Confirms that a device entry was deleted
        public async Task<Device> DeleteConfirmed(Guid id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return (device);
        }

        // Checks whether a device entry exists
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
