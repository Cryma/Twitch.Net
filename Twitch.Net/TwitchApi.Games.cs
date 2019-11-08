﻿using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Response;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private const string _getTopGamesEndpoint = "https://api.twitch.tv/helix/games/top";
        private const string _getGamesEndpoint = "https://api.twitch.tv/helix/games";

        public async Task<TwitchPaginatedResponse<TwitchGame>> GetTopGames(int first = 20, string after = null, string before = null)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getTopGamesEndpoint}?first={first}";

            if (string.IsNullOrEmpty(after) == false)
            {
                url += $"&after={after}";
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                url += $"&before={before}";
            }

            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchGame>>(responseStream);
        }

        public async Task<TwitchResponse<TwitchGame>> GetGames(string[] ids)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getGamesEndpoint}?{GetQueryForParameters("id", ids)}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchGame>>(responseStream);
        }

    }
}
