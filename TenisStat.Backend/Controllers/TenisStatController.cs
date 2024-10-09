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


        /// <summary>
        /// Cet api fournit la liste des joueurs selon leur classement général
        /// </summary>
        /// <returns>
        /// Liste d'objets au format rank, firstname + lastname
        /// </returns>
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

        /// <summary>
        /// Cet api retourne les informations du joueur
        /// </summary>
        /// <param name="id"> identifiant du joueur</param>
        /// <returns>infos du joueur</returns>
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

        /// <summary>
        /// cet Api renvoie Pays qui a le plus grand ratio de parties gagnées, IMC moyen de tous les joueurs, La médiane de la taille des joueurs
        /// </summary>
        /// <returns></returns>
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
