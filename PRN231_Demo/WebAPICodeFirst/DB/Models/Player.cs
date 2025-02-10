namespace WebAPICodeFirst.DB.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string NickName { get; set; }
        public DateTime JoinedDate { get; set; }
        public ICollection<PlayerInstrument> playerInstruments { get; set; }
    }
}
