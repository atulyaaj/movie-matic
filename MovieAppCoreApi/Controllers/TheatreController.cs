using BookMyShowBusiness.Services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private TheatreService _theatreService;
        public TheatreController(TheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet("GetTheatres")]
        public IEnumerable<Theatre> GetTheatres()
        {
            return _theatreService.GetTheatres();
        }

        [HttpPost("AddTheatre")]
        public IActionResult AddTheatre([FromBody] Theatre theatre)
        {
            _theatreService.AddTheatre(theatre);
            return Ok("Theatre created successfully!!");
        }

        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int theatreId)
        {
            _theatreService.DeleteTheatre(theatreId);
            return Ok("Theatre deleted successfully!!");
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre([FromBody] Theatre theatre)
        {
            _theatreService.UpdateTheatre(theatre);
            return Ok("Theatre updated successfully!!");
        }
        [HttpGet("GetTheatreById")]
        public Theatre GetTheatreById(int theatreId)
        {
            return _theatreService.GetTheatreById(theatreId);
        }
    }
}
