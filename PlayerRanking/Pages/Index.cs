using Microsoft.AspNetCore.Components;
using PlayerRanking.Data;
using System.Linq;
using System.Threading.Tasks;
using PlayerRanking.Models;

namespace PlayerRanking.Pages
{
    public partial class Index : ComponentBase 
    {
        private Player[] listedPlayers;
        private PlayerProfileData playerProfileData;
        private Filter currentFilter;

        public enum Filter
        {
            Favorites,
            Top5,
            Top10,
            Top20
        };

        protected override async Task OnInitializedAsync()
        {
            currentFilter = Filter.Top20;
            await GetPlayerList(20);
        }

        public string GetPlayerProfileHeader(PlayerProfileData bio)
        {
            return $"{bio.LastName}, {bio.FirstName} - Rank no.{bio.HeroRank}";
        }

        public async Task GetPlayerList(int rank)
        {
            listedPlayers = await playerService.GetRankings(1, rank);

            var favPlayers = playerService.GetFavoritePlayers();

            foreach (var player in listedPlayers)
            {
                player.IsFavorite = favPlayers.Any(p => p.PlayerId == player.PlayerId);
            }

            StateHasChanged();
        }

        public void FilterByFavoritePlayers()
        {
            listedPlayers = playerService.GetFavoritePlayers()
                .Select(PlayerService.ConvertToPlayer)
                .ToArray();

            StateHasChanged();
        }

        public string OnRowStyling(bool isFav)
        {
            if (isFav)
            {
                return "color: red;";
            }
            return "color: primary;";
        }

        public async Task GetPlayerBio(Player p)
        {
            if (p.Rank < 11)
            {
                playerProfileData = await playerService.GetPlayerBio(p.PlayerId);
            }
            else
            {
                playerProfileData = null;
            }

            StateHasChanged();
        }

        public async Task ToggleFavorite(Player player)
        {
            if (player.IsFavorite)
            {
                await RemoveFavorite(player.PlayerId);
            }
            else
            {
                await AddFavorite(player);
            }

            player.IsFavorite = !player.IsFavorite;

            if (currentFilter == Filter.Favorites)
            {
                FilterByFavoritePlayers();
            }

            StateHasChanged();
        }

        public async Task AddFavorite(Player player)
        {
            await playerService.AddFavorite(player);
        }

        public async Task RemoveFavorite(string playerId)
        {
            await playerService.RemoveFavorite(playerId);
        }
    }
}
