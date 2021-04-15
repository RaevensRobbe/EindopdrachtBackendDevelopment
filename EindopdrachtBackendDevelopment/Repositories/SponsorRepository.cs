using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eindopdracht.DataContext;
using EindopdrachtBackendDevelopment.Models;

namespace Eindopdracht.Repositories
{
    public interface ISponsorRepository
    {
        // Task<List<Sponsor>> GetSponsors();
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

        // public Task<List<Sponsor>> GetSponsors()
        // {
        //     throw new NotImplementedException();
        // }
    }
}
