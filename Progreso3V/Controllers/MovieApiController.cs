using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progreso3V.Interfaces;
using Progreso3V.Repositories;

namespace Progreso3V.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private IMovieRepository _movieRepository;

        public MovieApiController(IMovieRepository moRepository)
        {
            _movieRepository = moRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> ObtenerRespuestaMovieAPIAsync(string prompt)
        {
            string respuesta = await _movieRepository.DevuelveRespuestaAPI(prompt);
            return Ok(respuesta);
        }
    }
}
