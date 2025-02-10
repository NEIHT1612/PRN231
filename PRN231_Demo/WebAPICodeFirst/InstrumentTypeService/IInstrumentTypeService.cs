using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.InstrumentType;
using WebAPICodeFirst.DB.DTO.Player;

namespace WebAPICodeFirst.InstrumentTypeService
{
    public interface IInstrumentTypeService
    {
        Task CreateInstrumentType(CreateInstrumentTypeRequest request);
        Task<PageResponse<GetInstrumentTypeResponse>> GetInstrumentTypeAsync(UrlQueryParameters urlQueryParameters);
        Task<GetInstrumentTypeResponse> GetInstrumentTypeDetailAsync(int id);
        Task<bool> DeleteInstrumentAsync(int id);
        Task<bool> UpdateInstrumentAsync(int id, UpdateInstrumentTypeRequest instrumentRequest);

    }
}
