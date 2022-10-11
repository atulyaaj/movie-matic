using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingController : ControllerBase
    {
        private ShowTimingService _showTimingService;
        public ShowTimingController(ShowTimingService showTimingService)
        {
            _showTimingService = showTimingService;
        }

        [HttpGet("GetShowTimings")]
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _showTimingService.GetShowTimings();
        }

        [HttpPost("AddShowTiming")]
        public IActionResult AddShowTiming([FromBody] ShowTiming showTiming)
        {
            _showTimingService.AddShowTiming(showTiming);
            return Ok("Show Timing created successfully!!");
        }

        [HttpDelete("DeleteShowTiming")]
        public IActionResult DeleteShowTiming(int showTimingId)
        {
            _showTimingService.DeleteShowTiming(showTimingId);
            return Ok("Show Timing deleted successfully!!");
        }

        [HttpPut("UpdateShowTiming")]
        public IActionResult UpdateShowTiming([FromBody] ShowTiming showTiming)
        {
            _showTimingService.UpdateShowTiming(showTiming);
            return Ok("ShowTiming updated successfully!!");
        }
    }
}
