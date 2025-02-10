using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DB.DTO.Player
{
    public class UpdatePlayerRequest
    {
        [Required]
        public string NickName { get; set; }
    }
}
