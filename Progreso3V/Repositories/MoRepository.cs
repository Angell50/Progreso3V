using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Progreso3V.Repositories
{
    public class MovieRepository
    {
        public async Task<string> DevuelveRespuestaAPI(string pelicula)
        {
            string url = $"https://api.example.com/movies/{pelicula}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var stringContent = new StringContent(string.Empty, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, stringContent);
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    Models.MovieModels movie = JsonConvert.DeserializeObject<Models.MovieModels>(jsonResponse);

                    var resultado = new
                    {
                        Titulo = movie.title,
                        Genero = movie.genre?[0],
                        ActorPrincipal = movie.actors?[0],
                        Premios = movie.awards,
                        Website = movie.website,
                        Nombre = "AVela"
                    };

                    return JsonConvert.SerializeObject(resultado);
                }
                catch (Exception ex)
                {
                    return $"Error: No se encontró la película. Detalles: {ex.Message}";
                }
            }
        }
    }

   