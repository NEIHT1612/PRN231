using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPICodeFirst.DB;
using WebAPICodeFirst.DB.DTO;
using WebAPICodeFirst.DB.DTO.InstrumentType;
using WebAPICodeFirst.DB.DTO.PlayerInstrument;
using WebAPICodeFirst.DB.Models;

namespace WebAPICodeFirst.InstrumentTypeService
{
    public class InstrumentTypeService : IInstrumentTypeService
    {
        private readonly WebAPICodeFirstContext _context;
        private readonly IMapper _mapper;

        public InstrumentTypeService(WebAPICodeFirstContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateInstrumentType(CreateInstrumentTypeRequest request)
        {
            var instrumentType = _mapper.Map<InstrumentType>(request);
            await _context.InstrumentTypes.AddAsync(instrumentType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteInstrumentAsync(int id)
        {
            try
            {
                _context.PlayerInstruments.RemoveRange(_context.PlayerInstruments.Where(x => x.InstrumentId == id));

                await _context.SaveChangesAsync();

                _context.InstrumentTypes.Remove(_context.InstrumentTypes.FirstOrDefault(x => x.InstrumentId == id));

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<PageResponse<GetInstrumentTypeResponse>> GetInstrumentTypeAsync(UrlQueryParameters urlQueryParameters)
        {
            var result = new PageResponse<GetInstrumentTypeResponse>();

            try
            {
                IQueryable<InstrumentType> query = _context.InstrumentTypes;

                if (!string.IsNullOrEmpty(urlQueryParameters.Search))
                {
                    var searchValue = urlQueryParameters.Search;
                    query = query.Where(x => x.InstrumentName.Contains(searchValue));
                }

                result.TotalItems = await query.CountAsync();

                int page = urlQueryParameters.Page > 0 ? urlQueryParameters.Page : 1;
                int pageSize = urlQueryParameters.PageSize > 0 ? urlQueryParameters.PageSize : 10;

                var instrumentList = await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var instrumentIds = instrumentList.Select(i => i.InstrumentId).ToList();
                var playerInstruments = await _context.PlayerInstruments
                    .Where(pi => instrumentIds.Contains(pi.InstrumentId))
                    .ToListAsync();

                var responseList = instrumentList.Select(i => new GetInstrumentTypeResponse
                {
                    InstrumentId = i.InstrumentId,
                    InstrumentName = i.InstrumentName,
                    playerInstrument = playerInstruments.Where(pi => pi.InstrumentId == i.InstrumentId).ToList(),
                }).ToList();

                result.Data = responseList;
                result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / pageSize);

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public async Task<GetInstrumentTypeResponse> GetInstrumentTypeDetailAsync(int id)
        {
            var result = new GetInstrumentTypeResponse();

            try
            {
                var playerInstrument = await _context.PlayerInstruments.Where(x => x.InstrumentId == id).ToListAsync();

                var instrumentType = await _context.InstrumentTypes.FirstOrDefaultAsync(x => x.InstrumentId == id);

                result.playerInstrument = playerInstrument;
                result.InstrumentId = instrumentType.InstrumentId;
                result.InstrumentName = instrumentType.InstrumentName;

                return result;

            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public async Task<bool> UpdateInstrumentAsync(int id, UpdateInstrumentTypeRequest instrumentRequest)
        {
            try
            {
                var instrumentType = await _context.InstrumentTypes.FirstOrDefaultAsync(x => x.InstrumentId == id);

                if (instrumentType == null) return false;

                var mapper = _mapper.Map(instrumentRequest, instrumentType);

                _context.InstrumentTypes.Update(mapper);

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
