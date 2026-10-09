using WebAPI_Modelo.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI_Modelo.Repository
{
    public class CineRepository : ICineRepository
    {
        //Recibir context, mediante un constructor
        private readonly db_cineContext _context;
        public CineRepository(db_cineContext context)
        {
            _context = context;
        }

        // Implementación de los métodos de la interfaz ICineRepository
        public async Task<bool> ActualizarPeliculaAsync(Pelicula pelicula)
        {
            return await Task.Run(async () =>
            {
                var peliculaExistente = _context.Peliculas.FindAsync(pelicula.Id).Result;
                if (peliculaExistente == null)
                {
                    return false;
                }
                await _context.SaveChangesAsync();

                return true;
            });
        }

        public async Task<Pelicula> CrearPeliculaAsync(Pelicula pelicula)
        {
            var peliculaNueva = new Pelicula
            {
                Titulo = pelicula.Titulo,
                Director = pelicula.Director,
                Anio = pelicula.Anio,
                Estreno = true,
                IdGenero = pelicula.IdGenero
            };
            _context.Peliculas.Add(peliculaNueva);
            await _context.SaveChangesAsync();
            return peliculaNueva;

        }

        public async Task<List<Pelicula>> ObtenerPeliculasEnEstrenoAsync()
        {
            var peliculas = await _context.Peliculas.Where(p => p.Estreno).ToListAsync();
            if (peliculas == null || peliculas.Count == 0)
            {
                throw new Exception("No se encontraron películas en estreno.");
            }
            return peliculas;
        }
    }
}
