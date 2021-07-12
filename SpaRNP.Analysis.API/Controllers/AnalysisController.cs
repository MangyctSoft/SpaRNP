using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaRNP.Analysis.API.Services;
using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SpaRNP.Analysis.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisUserService _analysisUsersService;

        public AnalysisController(IAnalysisUserService analysisUsersService)
        {
            _analysisUsersService = analysisUsersService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnalysisUser>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _analysisUsersService.GetAll();

            if (result.Count() > 0)
            {
                return Ok(result);
            }

            return StatusCode(204);
        }

        [Route("calculate")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public decimal Calculate() => _analysisUsersService.Calculate();

        [Route("save")]
        [HttpPut]
        public async Task<IActionResult> Save([FromBody]List<AnalysisUser> users)
        {
            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            return await _analysisUsersService.Save(users).ContinueWith(a => a.IsCompleted ? Ok() : a.IsFaulted ? StatusCode(500) : BadRequest());
        }
    }
}
