using Api.DbContext;
using Api.DTOs.Request;
using Api.Helpers;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class ShowService : IShowService
    {
        private readonly ApplicationDbContext _context;
        public ShowService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedList<Show>> GetAllShows(QueryParams query)
        {
            return PagedList<Show>.BuildPageList(_context.Shows.AsNoTracking(),
                query.PageSize,
                query.PageNumber);
        }

        public async Task<Show> GetShowById(int id)
        {
            return await _context.Shows.FindAsync(id);
        }

        public async Task DeleteShowById(int id)
        {
            var showToDelete = await GetShowById(id);
            
            _context.Shows.Remove(showToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Show> CreateShow(Show show)
        {
            _context.Shows.Add(show);
            await _context.SaveChangesAsync();

            return show;
        }
    }

    public interface IShowService
    {
        Task<PagedList<Show>> GetAllShows(QueryParams query);
        Task<Show> GetShowById(int id);
        Task DeleteShowById(int id);
        Task<Show> CreateShow(Show show);
    }
}
