namespace WebAPICodeFirst.DB.DTO.InstrumentType
{
    public class GetInstrumentTypeResponse
    {
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public List<WebAPICodeFirst.DB.Models.PlayerInstrument> playerInstrument { get; set; }
    }
}
