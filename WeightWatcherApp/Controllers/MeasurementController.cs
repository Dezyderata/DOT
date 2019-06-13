using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeightWatcherApp.Core.Services;

namespace WeightWatcherApp.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class MeasurementController : ControllerBase
    {
        private readonly MeasurementService _measurementService;

        public MeasurementController(MeasurementService measurementService)
        {
            _measurementService = measurementService;
        }
        [HttpGet("GetMeas/{id}")]
        public async Task<IActionResult> GetAll(long id)
        {
            try
            {
                var measurements = await _measurementService.GetAll(id);
                return Ok(measurements);
            }
            catch (NullReferenceException e)
            {
                return NotFound($"Can't found measurements");
            }
        }
    }
}