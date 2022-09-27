using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IDevicesRepository : IGenericRepository<Device>
    {
        Device GetMostRecentDevice();
        SelectList showCat();
        SelectList showZone();
        bool Exists(Guid id);
        SelectList editCat(Guid? id);
        SelectList editZone(Guid? id);

    }

}
