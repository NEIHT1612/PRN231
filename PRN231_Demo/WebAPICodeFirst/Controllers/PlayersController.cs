using Microsoft.AspNetCore.Mvc;
using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.Player;
using WebAPICodeFirst.PlayerServices;

namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService) => _playerService = playerService;

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok(playerRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            await _playerService.DeletePlayerAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerAsync([FromQuery]UrlQueryParameters urlQueryParameters)
        {
            var players = await _playerService.GetPlayerAsync(urlQueryParameters);
            return Ok(players);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            var player = await _playerService.GetPlayerDetailAsync(id);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            if(id <= 0 || playerRequest == null)
            {
                return BadRequest(ModelState);
            }
            await _playerService.UpdatePlayerAsync(id, playerRequest);
            return Ok();
        }
    }
}
