using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeams();
    }

    public class TeamRepository : ITeamRepository
    {
        private ITeamContext _context;

        public TeamRepository(ITeamContext context){
            _context = context;
        }
        public async Task<List<Team>> GetTeams()
        {
            try
            {
                return await _context.Team.ToListAsync();
            }
            catch (System.Exception ex)
            {              
                throw ex;
            }
            
        }
    }
}
