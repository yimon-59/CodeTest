using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS_System_API.Model;
using POS_System_API.Service.Interface;

namespace POS_System_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;

        public PointController(IPointService pointService)
        {
            _pointService = pointService;
        }

        [HttpGet("{memberCode}")]
        public IActionResult Post(string memberCode)
        {
            // Perform validation or other necessary checks on the model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int result = _pointService.CalculatePoint(memberCode);
            if(result != 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}