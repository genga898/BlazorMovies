using BlazorMovies.Models;
using System.Net.Http.Json;

namespace BlazorMovies.Services
{
    public class TMDBClient
    {
        private readonly HttpClient _httpClient;

        public TMDBClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            string apiKey = config["TMDBApiKey"] ?? throw new Exception("TMDB Api Key was not found");
            _httpClient.DefaultRequestHeaders.Authorization = new ("Bearer" ,apiKey);
        }

        public Task<PopularMoviesPagedResponse?> GetPopularMoviesAsync(int page = 1)
        {
            if (page<1) page = 1;
            if (page>500) page = 500;
            return _httpClient.GetFromJsonAsync<PopularMoviesPagedResponse>($"movie/popular?page={page}");
        }

        public Task<MovieDetails?> GetMovieDetailsAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<MovieDetails>($"movie/{id}");
        }
    }
}
