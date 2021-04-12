using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Eindopdracht.Repositories;
using EindopdrachtBackendDevelopment.DTO;
using EindopdrachtBackendDevelopment.Models;

namespace EindopdrachtBackendDevelopment.Services
{
    public interface IFormulaService
    {
        Task<SponsorDTO> AddSponsor(SponsorDTO sponsor);
        Task<List<Driver>> GetDrivers();
        Task<List<Team>> GetTeams();

    }

    public class FormulaService : IFormulaService
    {
        private ITeamRepository _teamRepository;
        private IDriverRepository _driverRepository;
        private ISponsorRepository _sponsorRepository;
        private IMapper _mapper;

        public FormulaService(
            ITeamRepository teamRepository,
            IDriverRepository driverRepository,
            ISponsorRepository sponsorRepository,
            IMapper mapper)
        {
            _teamRepository = teamRepository;
            _driverRepository = driverRepository;
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetTeams();
        }
        public async Task<List<Driver>> GetDrivers()
        {
            return await _driverRepository.GetDrivers();
        }

        public async Task<SponsorDTO> AddSponsor(SponsorDTO sponsor)
        {
            try {
                
                Sponsor newSponsor = _mapper.Map<Sponsor>(sponsor);

                newSponsor.TeamSponsors = new List<TeamSponsors>();
                foreach (var teamId in sponsor.Team){
                //foreach (var sponsorId in sponsor.TeamSponsors){
                    newSponsor.TeamSponsors.Add(new TeamSponsors(){ TeamId = teamId});
                }
            
                await _sponsorRepository.AddSponsor(newSponsor);
            
                return sponsor;

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}