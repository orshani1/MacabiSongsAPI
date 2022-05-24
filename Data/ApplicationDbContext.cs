using MacabiSongsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MacabiSongsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)  
        {

        }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
