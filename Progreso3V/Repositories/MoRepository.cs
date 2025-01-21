using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Progreso3V.Interfaces;
using Progreso3V.Models;

namespace Progreso3V.Repositories
{
    public class MoRepository : IMovieRepository

    {
        public async Task<string> DevuelveRespuestaAPI(string pelicula)
        {
            string jsonData = JsonConvert.SerializeObject(pelicula);
            string url = $"https://api.example.com/movies/{pelicula}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(pelicula, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url);
                    response.EnsureSuccessStatusCode(); 

                    string jsonResponse = await response.Content.ReadAsStringAsync();

 
                    MovieModels movie = JsonConvert.DeserializeObject<MovieModels>(jsonResponse);

                    Console.WriteLine($"Título de la película: {movie.title}");
                    Console.WriteLine($"Género (1er registro): {movie.genre}");
                    Console.WriteLine($"Actor principal (1er registro): {movie.actors}");
                    Console.WriteLine($"Premios: {movie.awards}");
                    Console.WriteLine($"Website: {movie.website}");

                    return JsonConvert.SerializeObject(movie);
                }
                catch (Exception ex)
                {
                    return "No se encontró ninguna película" + ex;
                }
            }
        }
    }
}
