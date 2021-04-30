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
        Task<List<Driver>> GetDriver(int driverId);
        Task<List<Driver>> GetDrivers();
        Task<Driver> UpdateDriver(Driver updateDriver);
        Task<Driver> AddDriver(Driver addDriver);
        Task<Career> AddCareer(Career addCareer);
        Task<List<Team>> GetTeam(int teamId);
        Task<List<Team>> GetTeams(bool includeSponsor);
        Task<List<Team>> GetTeamPerCountry(string nationality);
        Task<Team> AddTeam(Team newTeam);
        Task<List<Sponsor>> GetSponsors();

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

        // Teams
        public async Task<List<Team>> GetTeam(int teamId)
        {
            try
            {
                return await _teamRepository.GetTeam(teamId); 
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
                return await _teamRepository.GetTeamPerCountry(nationality); 
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
                return await _teamRepository.GetTeams(includeSponsor);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }

        }

        public async Task<Team> AddTeam(Team newTeam)
        {
            try
            {
                return await _teamRepository.AddTeam(newTeam);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        // Drivers
        public async Task<List<Driver>> GetDriver(int driverId)
        {
            try
            {
                return await _driverRepository.GetDriver(driverId);
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }
        
        public async Task<List<Driver>> GetDrivers()
        {
            try
            {
                return await _driverRepository.GetDrivers();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

        public async Task<Driver> UpdateDriver(Driver updateDriver)
        {
            try
            {
                return await _driverRepository.UpdateDriver(updateDriver);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Driver> AddDriver(Driver addDriver)
        {
            try
            {
                return await _driverRepository.AddDriver(addDriver);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        public async Task<Career> AddCareer(Career addCareer)
        {
            try
            {
                return await _driverRepository.AddCareer(addCareer);
            }
            catch( System.Exception ex)
            {
                throw ex;
            } 
        }

        // Sponsors
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

        public async Task<List<Sponsor>> GetSponsors()
        {
            try
            {
                return await _sponsorRepository.GetSponsors();
            }
            catch (System.Exception ex)
            {
                
                throw ex;
            }
            
        }

    }
}
