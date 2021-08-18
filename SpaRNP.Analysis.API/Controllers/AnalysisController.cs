using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AnalysisController> _logger;
        public AnalysisController(IAnalysisUserService analysisUsersService, ILogger<AnalysisController> logger)
        {
            _analysisUsersService = analysisUsersService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AnalysisUser>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get request.");

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
        public decimal Calculate()
        {
            _logger.LogInformation("Calculate.");

            return _analysisUsersService.Calculate();
        }

        [Route("save")]
        [HttpPut]
        public async Task<IActionResult> Save([FromBody]List<AnalysisUser> users)
        {
            _logger.LogInformation("Save.");

            if (users == null)
            {
                throw new ArgumentNullException(nameof(users));
            }
            return await _analysisUsersService.Save(users).ContinueWith(a => a.IsCompleted ? Ok() : a.IsFaulted ? StatusCode(500) : BadRequest());
        }
    }
}
