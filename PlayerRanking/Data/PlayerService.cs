using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PlayerRanking.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlayerRanking.Data
{
    public class PlayerService
    {
        private readonly IDbContextFactory<AtpContext> contextFactory;
        private readonly IMemoryCache cache;

        public PlayerService(IDbContextFactory<AtpContext> contextFactory, IMemoryCache cache)
        {
            this.contextFactory = contextFactory;
            this.cache = cache;
        }

        public async Task<Player[]> GetRankings(int fromRank, int toRank)
        {
            
            using (var client = new HttpClient())
            {
                string uri = $"https://app.atptour.com/api/gateway/rankings.ranksglrollrange?fromrank={fromRank}&torank={toRank}";

                var result = await cache.GetOrCreateAsync(uri, async(entry) =>
                {
                    entry.SetSlidingExpiration(TimeSpan.FromSeconds(2));
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                    return await client.GetAsync(uri);
                });

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get rankings: {fromRank} to {toRank}");
                }

                var jsonResult = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<RankingsResponse>(jsonResult)?.Data?.Rankings?.Players;
            }
        }

        public async Task<PlayerProfileData> GetPlayerBio(string playerId)
        {
            using (var client = new HttpClient())
            {
                var uri = $"https://app.atptour.com/api/gateway/players.PlayerProfileBio?playerid={playerId}";

                var result = await cache.GetOrCreateAsync(uri, async (entry) =>
                {
                    entry.SetSlidingExpiration(TimeSpan.FromSeconds(2));
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                    return await client.GetAsync(uri);
                });

                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get player profile: PlayerId - {playerId}");
                }

                var jsonResult = await result.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<PlayerProfileResponse>(jsonResult)?.Data;
            }
        }

        public FavoritePlayer[] GetFavoritePlayers()
        {
            using (var atpContext = contextFactory.CreateDbContext())
            {
                return atpContext.FavoritePlayers.ToArray();
            }
        }

        public async Task AddFavorite(Player player)
        {
            using (var atpContext = contextFactory.CreateDbContext())
            {
                atpContext.FavoritePlayers.Add(ConvertToFavoritePlayer(player));
                await atpContext.SaveChangesAsync();
            }
        }
        public async Task RemoveFavorite(string playerId)
        {
            using (var atpContext = contextFactory.CreateDbContext())
            {
                var playerToBeRemoved = atpContext.FavoritePlayers.First(p => p.PlayerId == playerId);
                atpContext.FavoritePlayers.Remove(playerToBeRemoved);
                await atpContext.SaveChangesAsync();
            }
        }

        public static FavoritePlayer ConvertToFavoritePlayer(Player player)
        {
            return new Models.FavoritePlayer
            {
                PlayerId = player.PlayerId,
                FirstName = player.FirstName,
                LastName = player.LastName,
                AgeAtRankDate = player.AgeAtRankDate,
                CountryName = player.CountryName,
                IsTie = player.IsTie,
                LastWeekPosMove = player.LastWeekPosMove,
                NatlId = player.NatlId,
                NbrEventsPlayed = player.NbrEventsPlayed,
                NextBestPoints = player.NextBestPoints,
                PlayerGladiatorImageCmsUrl = player.PlayerGladiatorImageCmsUrl,
                PlayerHeadshotImageCmsUrl = player.PlayerHeadshotImageCmsUrl,
                Points = player.Points,
                PointsDropping = player.PointsDropping,
                PrevPoints = player.PrevPoints,
                PrevRank = player.PrevRank,
                Rank = player.Rank,
                Type = player.Type
            };
        }

        public static Player ConvertToPlayer(FavoritePlayer player)
        {
            return new Player
            {
                PlayerId = player.PlayerId,
                FirstName = player.FirstName,
                LastName = player.LastName,
                AgeAtRankDate = player.AgeAtRankDate,
                CountryName = player.CountryName,
                IsTie = player.IsTie,
                LastWeekPosMove = player.LastWeekPosMove,
                NatlId = player.NatlId,
                NbrEventsPlayed = player.NbrEventsPlayed,
                NextBestPoints = player.NextBestPoints,
                PlayerGladiatorImageCmsUrl = player.PlayerGladiatorImageCmsUrl,
                PlayerHeadshotImageCmsUrl = player.PlayerHeadshotImageCmsUrl,
                Points = player.Points,
                PointsDropping = player.PointsDropping,
                PrevPoints = player.PrevPoints,
                PrevRank = player.PrevRank,
                Rank = player.Rank,
                Type = player.Type,
                IsFavorite = true
            };
        }
    }
}
