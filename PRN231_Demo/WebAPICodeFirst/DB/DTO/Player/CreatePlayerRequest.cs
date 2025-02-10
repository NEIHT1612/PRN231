using System.ComponentModel.DataAnnotations;
using WebAPICodeFirst.DB.DTO.PlayerInstrument;

namespace WebAPICodeFirst.DB.DTO.Player
{
    public class CreatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
        public List<CreatePlayerInstrumentRequest> PlayerInstruments { get; set; }
    }
}
