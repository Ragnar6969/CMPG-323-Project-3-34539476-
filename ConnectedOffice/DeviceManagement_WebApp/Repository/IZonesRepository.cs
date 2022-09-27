using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        Zone GetMostRecentZone();
        bool Exists(Guid id);
    }

}
