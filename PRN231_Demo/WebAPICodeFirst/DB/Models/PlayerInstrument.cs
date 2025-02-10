using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPICodeFirst.DB.Models
{
    public class PlayerInstrument
    {
        [Key]
        public int PlayerInstrumentId { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
        
        public int InstrumentId { get; set; }
        public InstrumentType InstrumentType { get; set; }

        public string ModelName { get; set; }
        public string Level { get; set; }

        
    }
}
