using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB;
using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.Player;
using WebAPICodeFirst.DB.DTO.PlayerInstrument;
using WebAPICodeFirst.DB.Models;

namespace WebAPICodeFirst.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly WebAPICodeFirstContext _context;
        private readonly IMapper _mapper;
        public PlayerService(WebAPICodeFirstContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreatePlayerAsync(CreatePlayerRequest playerRequest)
        {
            var player = _mapper.Map<Player>(playerRequest);
            player.JoinedDate = DateTime.Now;
            var playerAdded = await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePlayerAsync(int id)
        {
            try
            {
                _context.PlayerInstruments.RemoveRange(_context.PlayerInstruments.Where(pi => pi.PlayerId == id));
                await _context.SaveChangesAsync();

                _context.Players.Remove(_context.Players.FirstOrDefault(p => p.PlayerId == id));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<PageResponse<GetPlayerResponse>> GetPlayerAsync(UrlQueryParameters urlQueryParameters)
        {
            try
            {
                var players = _context.Players.Include(i => i.playerInstruments).AsQueryable();
                var search = urlQueryParameters.Search;
                if (!string.IsNullOrEmpty(search))
                {
                    players = players.Where(s => s.NickName.Contains(search));
                }
                var totalItems = await players.CountAsync();
                List<GetPlayerResponse> data;
                int totalPages = 0;
                var page = urlQueryParameters.Page;
                var pageSize = urlQueryParameters.PageSize;
                if (page == 0 && pageSize == 0)
                {
                    data = _mapper.Map<List<GetPlayerResponse>>(await players.ToListAsync());
                }
                else
                {
                    var pageStart = page - 1;
                    totalPages = (int)Math.Ceiling(totalItems / (float)pageSize);
                    data = _mapper.Map<List<GetPlayerResponse>>(await players.Skip(pageStart * pageSize).Take(pageSize).ToListAsync());
                }
                var pageResponse = new PageResponse<GetPlayerResponse>(data, page, pageSize, totalPages, totalItems);
                return pageResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetPlayerDetailResponse> GetPlayerDetailAsync(int id)
        {
            try
            {
                var player = await _context.Players.Include(i => i.playerInstruments).FirstOrDefaultAsync(e => e.PlayerId == id);
                var playerMapper = _mapper.Map<GetPlayerDetailResponse>(player);
                playerMapper.PlayerInstruments = _mapper.Map<List<GetPlayerInstrumentResponse>>(player.playerInstruments);
                return playerMapper;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdatePlayerAsync(int id, UpdatePlayerRequest playerRequest)
        {
            try
            {
                var player = await _context.Players.FirstOrDefaultAsync(e => e.PlayerId == id);
                player.NickName = playerRequest.NickName;
                _context.Players.Update(player);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
