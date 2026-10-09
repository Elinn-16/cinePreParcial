using WebAPI_Modelo.Models;

namespace WebAPI_Modelo.Repository
{
    public interface ICineRepository
    {
        Task<List<Pelicula>> ObtenerPeliculasEnEstrenoAsync();
        Task<Pelicula> CrearPeliculaAsync(Pelicula pelicula);
        Task<bool> ActualizarPeliculaAsync(Pelicula pelicula);
    }
}
