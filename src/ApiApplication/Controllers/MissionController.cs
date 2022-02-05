using Domain.Commands.Interfaces;
using Domain.Helpers;
using Domain.Models;
using Domain.Models.Extensions;
using Domain.Queries.Interfaces;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IMissionService _missionService;
        private readonly IGetStatisticsQuery _getStatisticsQuery;
        private readonly ISaveMissionResultCommand _saveMissionResultCommand;
        private readonly bool _saveMissionInputOutput;

        public MissionController(IConfiguration configuration, IMissionService missionService, IGetStatisticsQuery getStatisticsQuery, 
            ISaveMissionResultCommand saveMissionResultCommand)
        {
            _configuration = configuration;
            _missionService = missionService;
            _getStatisticsQuery = getStatisticsQuery;
            _saveMissionResultCommand = saveMissionResultCommand;
            bool.TryParse(_configuration.GetSection("AppSettings").GetSection("SaveMissionInputOutput").Value, out _saveMissionInputOutput);
        }

        [HttpGet("stats/{id}")]
        public ActionResult<MissionResult> Statistics(int id)
        {
            var stats = _getStatisticsQuery.Execute(id);

            return Ok(stats.Result);
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
        public ActionResult<string> Launch([FromForm] MissionParameters missionParameters)
        {
            var missionInput = InputParser.ParseInput(missionParameters.Input);
            var missionValidation = _missionService.ValidateMission(missionInput);

            if (!missionValidation.Success)
            {
                return BadRequest(missionValidation.GetMessagesAsString());
            }

            var missionResult = _missionService.LaunchMission(missionInput);

            if (_saveMissionInputOutput)
            {
                _saveMissionResultCommand.Execute(missionResult.Result, missionParameters);
            }

            return Ok(missionResult.Result.GetWrittenMissionReport());
        }
    }
}
