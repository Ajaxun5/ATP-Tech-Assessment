using Microsoft.EntityFrameworkCore;
using PlayerRanking.Models;

namespace PlayerRanking.Data
{
    public class AtpContext : DbContext
    {
        public DbSet<FavoritePlayer> FavoritePlayers { get; set; }

        public AtpContext(DbContextOptions options) : base(options)
        {

        }
    }
}
