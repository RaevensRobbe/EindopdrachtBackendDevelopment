using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeam(int teamId);
        Task<List<Team>> GetTeams(bool includeSponsor);
        Task<List<Team>> GetTeamPerCountry(string nationality);
    }

    public class TeamRepository : ITeamRepository
    {
        private ITeamContext _context;

        public TeamRepository(ITeamContext context){
            _context = context;
        }
        public async Task<List<Team>> GetTeam(int teamId)
        {
            try
            {
                return await _context.Team.Where(s => s.TeamId == teamId).Include(s => s.TeamSponsors).ThenInclude(s => s.Sponsor).ToListAsync();
            }
            catch (System.Exception ex)
            {              
                throw ex;
            }
        }

        public async Task<List<Team>> GetTeamPerCountry(string nationality)
        {
            try
            {
                return await _context.Team.Where(s => s.Location == nationality).Include(s => s.TeamSponsors).ThenInclude(s => s.Sponsor).ToListAsync();
            }
            catch (System.Exception ex)
            {              
                throw ex;
            }
        }

        public async Task<List<Team>> GetTeams(bool includeSponsor)
        {
            try
            {
                if (includeSponsor) {
                    return await _context.Team.Include(s => s.TeamSponsors).ThenInclude(s => s.Sponsor).ToListAsync();
                } else {
                    return await _context.Team.ToListAsync();
                }

            }
            catch (System.Exception ex)
            {              
                throw ex;
            }
        }
    }
}
