using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using EindopdrachtBackendDevelopment.DTO;
using EindopdrachtBackendDevelopment.Models;
using EindopdrachtBackendDevelopment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EindopdrachtBackendDevelopment.Controllers
{
    [Authorize]
    [ApiController]
    public class FormulaOneController : ControllerBase
    {
        private IFormulaService _formulaService;

        public FormulaOneController(IFormulaService formulaService){
            _formulaService = formulaService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/team/{teamId}")]
        public async Task<ActionResult<List<Team>>> GetTeams(int teamId){
            try {
                return new OkObjectResult(await _formulaService.GetTeam(teamId));
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/teams/{nationality}")]
        public async Task<ActionResult<List<Team>>> GetTeamPerCountry(string nationality){
            try {
                return new OkObjectResult(await _formulaService.GetTeamPerCountry(nationality));
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/teams")]
        public async Task<ActionResult<List<Team>>> GetTeams(bool includeSponsor){
            try {
                return new OkObjectResult(await _formulaService.GetTeams(includeSponsor));
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }

        // API KEY NODIG VOOR VOLGENDE CALLS
        
        [HttpGet]
        [Route("/drivers")]
        public async Task<ActionResult<List<Driver>>> GetDrivers(){
            try {
                return new OkObjectResult(await _formulaService.GetDrivers());
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }
        
        [HttpGet]
        [Route("/driver/{driverId}")]
        public async Task<ActionResult<List<Driver>>> GetDriver(int driverId){
            try {
                return new OkObjectResult(await _formulaService.GetDriver(driverId));
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/sponsors")]
        public async Task<ActionResult<List<Sponsor>>> GetSponsor(){
            try {
                return new OkObjectResult(await _formulaService.GetSponsors());
            } catch (Exception ex) {
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/sponsors")]
        public async Task<ActionResult<SponsorDTO>> AddSponsor(SponsorDTO sponsor) {
            try
            {
                return new OkObjectResult(await _formulaService.AddSponsor(sponsor));
            }
            catch (Exception ex)
            {    
                Debug.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }
    }
}
