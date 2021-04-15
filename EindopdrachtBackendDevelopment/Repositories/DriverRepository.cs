using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetDrivers();
        Task<List<Driver>> GetDriver(int driverId);
    }

    public class DriverRepository : IDriverRepository
    {
        private ITeamContext _context;

        public DriverRepository(ITeamContext context){
            _context = context;
        }
        
        public async Task<List<Driver>> GetDrivers()
        {
            return await _context.Driver.Include(s => s.Career).ToListAsync();
        }

        public async Task<List<Driver>> GetDriver(int driverId)
        {
            return await _context.Driver.Where(s => s.DriverId == driverId).Include(s => s.Career).ToListAsync();
        }
    }
}
