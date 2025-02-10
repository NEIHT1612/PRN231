namespace WebAPICodeFirst.DB.DTO.PlayerInstrument
{
    public class GetPlayerInstrumentResponse
    {
        public int PlayerInstrumentId { get; set; }
        public int PlayerId { get; set; }
        public int InstrumentId { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
