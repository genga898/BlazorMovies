﻿using System.Text.Json.Serialization;

namespace BlazorMovies.Models
{
    public partial class PopularMoviesPagedResponse
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("results")]
        public IEnumerable<PopularMovie> Results { get; set; } = [];
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

    }
}
