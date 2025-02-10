namespace WebAPICodeFirst.DB.DTO.Player
{
    public class GetPlayerResponse
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public int InstrumentSubmittedCount { get; set; }
    }
}
