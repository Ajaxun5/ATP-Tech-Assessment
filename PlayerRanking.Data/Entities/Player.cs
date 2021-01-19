using Microsoft.EntityFrameworkCore;

namespace PlayerRanking.Data.Entities
{
    public class Player
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class PlayerContext : DbContext 
    {
        public PlayerContext(DbContextOptions options) : base(options)
        {

        }
    }
}
