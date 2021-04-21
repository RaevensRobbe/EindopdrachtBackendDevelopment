using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace Eindopdracht.Repositories
{
    public interface ISponsorRepository
    {
        Task<List<Sponsor>> GetSponsors();
        Task<Sponsor> AddSponsor(Sponsor sponsor);
        // Task<Sponsor> GetSponsor(Guid sponsorId);
    }

    public class SponsorRepository : ISponsorRepository
    {
        private ITeamContext _context;
        
        public SponsorRepository(ITeamContext context){
            _context = context;
        }

        public async Task<Sponsor> AddSponsor(Sponsor sponsor)
        {
            await _context.Sponsor.AddAsync(sponsor);
            await _context.SaveChangesAsync();
            return sponsor;
        }

        // public Task<Sponsor> GetSponsor(Guid sponsorId)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<List<Sponsor>> GetSponsors()
        {
            return await _context.Sponsor.ToListAsync();
        }
    }
}
