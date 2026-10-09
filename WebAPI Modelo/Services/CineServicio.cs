using Microsoft.EntityFrameworkCore;
using WebAPI_Modelo.DTOs;
using WebAPI_Modelo.Models;
using WebAPI_Modelo.Repository;

namespace WebAPI_Modelo.Services
{
    public class CineServicio : ICineServicio
    {
        private readonly ICineRepository _cineRepository;
        public CineServicio(ICineRepository cineRepository)
        {
            _cineRepository = cineRepository;
        }


        public async Task<bool> ActualizarPeliculaAsync(int id)
        {
            var resultado = await _cineRepository.ActualizarPeliculaAsync(new Pelicula { Id = id });
            return resultado;
        }

        public async Task<DetallePeliculaDTO> CrearPeliculaAsync(CrearPeliculaDTO dto)
        {
            var pelicula = new Pelicula
            {
                Titulo = dto.Titulo,
                Director = dto.Director,
                Anio = dto.Anio,
                Estreno = true,
                IdGenero = dto.IdGenero
            };
            //llamamos al repositorio para guardar la pelicula
            var peliculaCreada = await _cineRepository.CrearPeliculaAsync(pelicula);
            return new DetallePeliculaDTO
            {
                Id = peliculaCreada.Id,
                Titulo = peliculaCreada.Titulo,
                Director = peliculaCreada.Director,
                Anio = peliculaCreada.Anio,
                Genero = peliculaCreada.IdGeneroNavigation.Nombre
            };
        }

        public async Task<List<PeliculasCarteleraDTO>> ObtenerPeliculasEnEstrenoAsync()
        {
            // Llamar al método del repositorio para obtener las películas en estreno
            var peliculas = await _cineRepository.ObtenerPeliculasEnEstrenoAsync();
            var peliculasDTO = peliculas.Select(p => new PeliculasCarteleraDTO
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Director = p.Director,
                Anio = p.Anio,
                Estreno = p.Estreno,
                Genero = p.IdGeneroNavigation.Nombre
            }).ToList();

            return peliculasDTO; 
        }
    }
}
