using WebAPICodeFirst.DB.DTO.PlayerInstrument;

namespace WebAPICodeFirst.DB.DTO.Player
{
    public class GetPlayerDetailResponse
    {
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public List<GetPlayerInstrumentResponse> PlayerInstruments { get; set; }
    }
}
