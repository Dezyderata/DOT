using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeightWatcherApp.Contract.MeasurementDto;
using WeightWatcherApp.Contract.UserDto;
using WeightWatcherApp.Core.Services;
using WeightWatcherApp.Infrastructure.Repository;

namespace WeightWatcherApp.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMeasurementService _measurementService;

        public UserController(IUserService userService, IMeasurementService measurementService)
        {
            _userService = userService;
            _measurementService = measurementService;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var user = await _userService.GetById(id);
                
                return Ok(user);
            }
            catch (NullReferenceException e)
            {
                return NotFound($"Can't found user with id = {id}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.Add(user);
            return Created("Created new user", user);
        }

        [HttpPost("{id}/PostMeas")]
        public async Task<IActionResult> CreateMeasurement([FromBody] MeasurementDto measurementDto, long id)
        {
            if (measurementDto == null)
            {
                return BadRequest();
            }
            var userDto = await _userService.GetById(id);
            if (userDto == null)
            {
                return BadRequest();
            }
            await _measurementService.Add(measurementDto, userDto);
            return Created("Created new measurement record", measurementDto);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.Update(user);
            return Ok($"User updated");
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            await _userService.Delete(id);
            return Ok($"User with id ={id} deleted");
        }
        /*[HttpGet("GetMeas/{id}")]
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
        }*/

    }
}