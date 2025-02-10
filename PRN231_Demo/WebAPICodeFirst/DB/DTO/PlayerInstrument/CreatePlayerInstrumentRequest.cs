namespace WebAPICodeFirst.DB.DTO.PlayerInstrument
{
    public class CreatePlayerInstrumentRequest
    {
        public int PlayerId { get; set; }
        public int InstrumentId { get; set; }
        public string ModelName { get; set; }
        public string Level { get; set; }
    }
}
