using System.ComponentModel.DataAnnotations;

namespace PlayerRanking.Models
{
    public class FavoritePlayer
    {
        public string Type { get; set; }
        [Key]
        public string PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NatlId { get; set; }
        public string CountryName { get; set; }
        public int AgeAtRankDate { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public bool IsTie { get; set; }
        public int NbrEventsPlayed { get; set; }
        public int PrevRank { get; set; }
        public int PrevPoints { get; set; }
        public int PointsDropping { get; set; }
        public int NextBestPoints { get; set; }
        public int LastWeekPosMove { get; set; }
        public string PlayerGladiatorImageCmsUrl { get; set; }
        public string PlayerHeadshotImageCmsUrl { get; set; }
    }
}
