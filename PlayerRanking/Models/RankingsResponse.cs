using System;

namespace PlayerRanking.Models
{
    public class RankingsResponse
    {
        public RankingsContent Content { get; set; }
        public RankingData Data { get; set; }
    }

    public class RankingsContent
    {
        public string Advert { get; set; }
        public ContentModel RankingsContentModel { get; set; }
    }

    public class ContentModel
    {
        public string RankingsSponsorUri { get; set; }
    }

    public class RankingData
    {
        public RankingsDTO Rankings { get; set; }
    }

    public class RankingsDTO
    {
        public DateTime RankDate { get; set; }
        public string Type { get; set; }
        public Player[] Players { get; set; }
    }

    public class Player
    {
        public string Type { get; set; }
        public string PlayerId { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
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
        public bool IsFavorite { get; set; }
    }
}
