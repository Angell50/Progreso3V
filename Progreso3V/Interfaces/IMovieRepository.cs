namespace Progreso3V.Interfaces
{
    public interface IMovieRepository
    {
        Task<string> DevuelveRespuestaAPI(string prompt);
    }
}
