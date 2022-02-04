using Domain.Helpers;
using Domain.Models.Extensions;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [ApiController]
    public class MissionController : Controller
    {
        private readonly MissionService _missionService;

        public MissionController(MissionService missionService)
        {
            _missionService = missionService;
        }

        [HttpGet("stats/{id}")]
        public void Statistics(int id)
        {

        }

        [HttpPost]
        public string Launch(string input)
        {
            var missionInput = InputParser.ParseInput(input);
            var missionValidation = _missionService.ValidateMission(missionInput);

            if (!missionValidation.Success)
            {

            }

            var missionResult = _missionService.LaunchMission(missionInput);

            return missionResult.Result.GetWrittenMissionReport();
        }
    }
}
