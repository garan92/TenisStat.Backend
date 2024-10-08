using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenisStat.Backend.Contracts;
using TenisStat.Backend.Models;
using TenisStat.Backend.Models.Responses;
using TenisStat.Backend.Repository;
namespace TenisStat.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenisStatController : ControllerBase
    {
        private readonly ILogger<TenisStatController> _logger;
        private readonly ITenisStatRepository _tenisStatRepository;

        public TenisStatController(ILogger<TenisStatController> logger, ITenisStatRepository tenisStatRepository)
        {
            _logger = logger;
            _tenisStatRepository = tenisStatRepository;
        }

        [HttpGet("GetPlayersRanking")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PlayerRanking>))]
        public IActionResult GetplayersRanking()
        {
            try
            {
                var result = _tenisStatRepository.GetplayersRanking();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

        }

        [HttpGet("GetPlayerById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Player))]
        public IActionResult GetPlayerById(int id)
        {
            try
            {
                Player player = _tenisStatRepository.GetPlayerById(id);
                return Ok(player);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message); 
            }
        }
       

        [HttpGet("GetGlobalStatistics")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalStatistics))]
        public IActionResult GetGlobalStatistics()
        {
            try
            {
                var result = _tenisStatRepository.GetGlobalStatistics();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

        }
    }
}
