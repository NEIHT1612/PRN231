using System.ComponentModel.DataAnnotations;

namespace WebAPICodeFirst.DB.DTO.InstrumentType
{
    public class UpdateInstrumentTypeRequest
    {
        [Required]
        public string InstrumentName { get; set; }
    }
}
