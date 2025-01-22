using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Progreso3V.Interfaces;

namespace Progreso3V.Repositories
{
    public class MovieAPIRepository : IMovieRepository
    {
        public async Task<string> DevuelveRespuestaAPI(string pelicula)
        {
            string url = $"https://freetestapi.com/api/v1/movies?search={pelicula}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Models.MovieAPIModels> movies = JsonConvert.DeserializeObject<List<Models.MovieAPIModels>>(jsonResponse);

                    if (movies == null || movies.Count == 0)
                    {
                        return "Error: No se encontró la película.";
                    }

                    var movie = movies[0]; 

                    var resultado = new
                    {
                        Titulo = movie.title,
                        Genero = movie.genre != null && movie.genre.Count > 0 ? movie.genre[0] : "Desconocido",
                        ActorPrincipal = movie.actors != null && movie.actors.Count > 0 ? movie.actors[0] : "Desconocido",
                        Premios = movie.awards,
                        Website = movie.website,
                        Nombre = "AVela"
                    };

                    return JsonConvert.SerializeObject(resultado);
                }
                catch (JsonException jsonEx)
                {
                    return $"Error: Problema al deserializar la respuesta JSON. Detalles: {jsonEx.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error: No se encontró la película. Detalles: {ex.Message}";
                }
            }
        }
    }
}