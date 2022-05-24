using MacabiSongsAPI.Data;
using MacabiSongsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MacabiSongsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Song>> GetAllSongs()
        {
            return await _context.Songs.Select(a => a).ToListAsync();
        }

        [Route("{id}")]
        [HttpGet]

        public async Task<Song?> GetSingleSong(int id)
        {
            return await _context.Songs.Select(s => s).Where(s => s._id == id).FirstOrDefaultAsync();
        }
        [Route("{id}")]
        [HttpPatch]
        public async Task<Song?> PutSingleSong(int id)
        {
            var updatedSong = await _context.Songs.SingleOrDefaultAsync(s => s._id == id);
            if (updatedSong != null)
            {
                if (updatedSong.isSelected)
                {
                updatedSong.isSelected = false;
                _context.SaveChanges();

                }
                else
                {
                    updatedSong.isSelected = true;
                    _context.SaveChanges();

                }
            }
            return updatedSong;

        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<bool> DeleteSingleSong(int id)
        {
           var song =  _context.Songs.Find(id);
             _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        public async Task<bool> PostSingleSong(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync(true);
            return true;
        }

    }
}
