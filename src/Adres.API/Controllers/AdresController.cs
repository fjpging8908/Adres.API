using Adres.API.Data.Contracts.Dto;
using Adres.API.Data.Contracts.Requests;
using Adres.API.Model;
using Adres.API.Services.Interfaces;
using LP.Common.Payin.Requests;
using LP.Common.Payout.Requests;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Adres.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdresController : ControllerBase
    {
        private readonly IAcquisitionRequirementService _RequirementService;

        public AdresController(IAcquisitionRequirementService RequirementService)
        {
            _RequirementService = RequirementService;
        }

        /// <summary>
        /// Create Acquisition Requirements 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(AcquisitionRequerimentRequest request)
        {
            var result = _RequirementService.Create(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AcquisitionFilter filter)
        {
            var result = _RequirementService.GetAcquisitionRequirements(filter);            
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = _RequirementService.GetAcquisictionRequirements(Id);
            return Ok(result);
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(int Id, AcquisitionRequerimentRequest request)
        {
            var result = _RequirementService.Update(Id, request);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var result = _RequirementService.Delete(Id);
            return Ok(result);
        }

    }
}