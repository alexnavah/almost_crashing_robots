using Domain.Helpers;
using Domain.Models;
using Domain.Models.Extensions;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace ApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMissionService _missionService;
        private readonly bool _saveMissionInputOutput;

        public MissionController(IConfiguration configuration, IMissionService missionService)
        {
            _configuration = configuration;
            _missionService = missionService;

            bool.TryParse(_configuration.GetSection("AppSettings").GetSection("SaveMissionInputOutput").Value, out _saveMissionInputOutput);
        }

        [HttpGet("stats")]
        public void Statistics()
        {

        }

        [HttpGet("stats/{id}")]
        public int Statistics(int id)
        {
            return id;
        }

        [HttpPost]
        [Route("Launch/GivenSample")]
        public ActionResult<string> LaunchGivenSample()
        {
            var parameters = new MissionParameters
            {
                Name = "Code challenge given",
                Input = "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL"
            };

            return Launch(parameters);
        }

        [HttpPost]
        [Route("Launch")]
        public ActionResult<string> Launch([FromForm] MissionParameters parameters)
        {
            var missionInput = InputParser.ParseInput(parameters.Input);
            var missionValidation = _missionService.ValidateMission(missionInput);

            if (!missionValidation.Success)
            {
                return BadRequest(missionValidation.GetMessagesAsString());
            }

            var inputId = _saveMissionInputOutput ? _missionService.SaveMissionInput(parameters.Input, parameters.Name) : Guid.Empty;

            var missionResult = _missionService.LaunchMission(missionInput);

            if (_saveMissionInputOutput)
            {
                var outputId = _missionService.SaveMissionOutput(missionResult.Result.GetRawOutput(), inputId, missionResult.Result);
                _missionService.SetMissionOutput(inputId, outputId);
            }

            return Ok(missionResult.Result.GetWrittenMissionReport());
        }
    }
}
