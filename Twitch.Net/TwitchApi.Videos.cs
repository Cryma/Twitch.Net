﻿using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Response;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        public const string _getVideosEndpoint = "https://api.twitch.tv/helix/videos";

        public async Task<TwitchResponse<TwitchVideo>> GetVideos(string[] videoIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(videoIds.Select(videoId => new KeyValuePair<string, string>("id", videoId)));

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchVideo>>(responseStream);
        }

        public async Task<TwitchPaginatedResponse<TwitchVideo>> GetVideosFromGame(string gameId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("game_id", gameId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (string.IsNullOrEmpty(language) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("language", language));
            }

            if (string.IsNullOrEmpty(period) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("period", period));
            }

            if (string.IsNullOrEmpty(sort) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("sort", sort));
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("type", type));
            }

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchVideo>>(responseStream);
        }

        public async Task<TwitchPaginatedResponse<TwitchVideo>> GetVideosFromUser(string userId, int first = 20, string after = null, string before = null,
            string language = null, string period = null, string sort = null, string type = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            if (string.IsNullOrEmpty(language) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("language", language));
            }

            if (string.IsNullOrEmpty(period) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("period", period));
            }

            if (string.IsNullOrEmpty(sort) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("sort", sort));
            }

            if (string.IsNullOrEmpty(type) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("type", type));
            }

            var responseStream = await httpClient.GetAsync(_getVideosEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchVideo>>(responseStream);
        }

    }
}
