using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetDrivers();
    }

    public class DriverRepository : IDriverRepository
    {
        private ITeamContext _context;

        public DriverRepository(ITeamContext context){
            _context = context;
        }
        
        public async Task<List<Driver>> GetDrivers()
        {
            return await _context.Driver.ToListAsync();
        }
    }
}
