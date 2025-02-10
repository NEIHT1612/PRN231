using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.InstrumentType;
using WebAPICodeFirst.DB.DTO.Player;
using WebAPICodeFirst.InstrumentTypeService;

namespace WebAPICodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentTypeController : ControllerBase
    {
        private readonly IInstrumentTypeService _instrumentTypeService;

        public InstrumentTypeController(IInstrumentTypeService instrumentTypeService)
        {
            _instrumentTypeService = instrumentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> PostInstrumentTypeAsync([FromBody] CreateInstrumentTypeRequest instrumentTypeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.CreateInstrumentType(instrumentTypeRequest);
            return Ok(instrumentTypeRequest);
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var instruments = await _instrumentTypeService.GetInstrumentTypeAsync(urlQueryParameters);
            return Ok(instruments);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetInstrumentTypeDetailAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            var instrumentType = await _instrumentTypeService.GetInstrumentTypeDetailAsync(id);
            return Ok(instrumentType);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PutInstrumentAsync(int id, UpdateInstrumentTypeRequest instrumentRequest)
        {
            if (id <= 0 || instrumentRequest == null)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.UpdateInstrumentAsync(id, instrumentRequest);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInstrumentAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.DeleteInstrumentAsync(id);
            return Ok();
        }
    }
}
