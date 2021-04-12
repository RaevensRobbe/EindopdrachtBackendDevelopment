using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using EindopdrachtBackendDevelopment.DTO;
using EindopdrachtBackendDevelopment.Models;
using EindopdrachtBackendDevelopment.Services;
using Microsoft.AspNetCore.Mvc;

namespace EindopdrachtBackendDevelopment.Controllers
{
    [ApiController]
    public class FormulaOneController : ControllerBase
    {
        private IFormulaService _formulaService;

        public FormulaOneController(IFormulaService formulaService){
            _formulaService = formulaService;
        }

        [HttpGet]
        [Route("/teams")]
        public async Task<ActionResult<List<Team>>> GetTeams(){
            try {
                return new OkObjectResult(await _formulaService.GetTeams());
            } catch (Exception ex) {
                throw ex;
            }

        }

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

        [HttpPost]
        [Route("/sponsors")]
        public async Task<ActionResult<SponsorDTO>> AddSponsor(SponsorDTO sponsor) {
            try
            {
                return new OkObjectResult(await _formulaService.AddSponsor(sponsor));
            }
            catch (Exception ex)
            {    
                throw ex;
            }
        }
    }
}
