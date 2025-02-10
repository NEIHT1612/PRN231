using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.Player;

namespace WebAPICodeFirst.PlayerServices
{
    public interface IPlayerService
    {
        Task CreatePlayerAsync(CreatePlayerRequest request);
        Task<bool> DeletePlayerAsync(int id);
        Task<PageResponse<GetPlayerResponse>> GetPlayerAsync(UrlQueryParameters urlQueryParameters);
        Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id);
        Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest);

    }
}
