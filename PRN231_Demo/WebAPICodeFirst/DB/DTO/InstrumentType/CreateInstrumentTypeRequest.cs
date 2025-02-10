using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DB.DTO.InstrumentType
{
    public class CreateInstrumentTypeRequest
    {
        [Required]
        public int InstrumentId { get; set; }
        public string InstrumentName { get; set; }
    }
}
