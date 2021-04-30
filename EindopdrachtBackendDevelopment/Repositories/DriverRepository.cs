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
        Task<Driver> UpdateDriver(Driver updateDriver);
        Task<Driver> AddDriver(Driver addDriver);
        Task<Career> AddCareer(Career addCareer);
        
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

        public async Task<Driver> UpdateDriver(Driver updateDriver)
        {
            _context.Driver.Update(updateDriver);
            await _context.SaveChangesAsync();
            return updateDriver;
        }

        public async Task<Driver> AddDriver(Driver addDriver)
        {
            await _context.Driver.AddAsync(addDriver);
            await _context.SaveChangesAsync();
            return addDriver;
        }
        public async Task<Career> AddCareer(Career addCareer)
        {
            await _context.Career.AddAsync(addCareer);
            await _context.SaveChangesAsync();
            return addCareer;
        }
    }
}
