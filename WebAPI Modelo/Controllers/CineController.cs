using Microsoft.AspNetCore.Mvc;
using WebAPI_Modelo.Services;
using System.Threading.Tasks;
using System;
using WebAPI_Modelo.DTOs;

namespace WebAPI_Modelo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CineController : ControllerBase
    {
        private readonly ICineServicio _cineServicio;
        public CineController(ICineServicio cineServicio)
        {
            _cineServicio = cineServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPeliculasEnEstreno()
        {
            try
            {
                var peliculas = await _cineServicio.ObtenerPeliculasEnEstrenoAsync();
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener las películas en estreno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearPelicula([FromBody] CrearPeliculaDTO dto)
        {
            try
            {
                var peliculaCreada = await _cineServicio.CrearPeliculaAsync(dto);
                return Ok(peliculaCreada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la película: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPelicula(int id)
        {
            try
            {
                var resultado = await _cineServicio.ActualizarPeliculaAsync(id);
                if (!resultado)
                {
                    return NotFound($"No se encontró la película con ID {id} para actualizar.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar la película: {ex.Message}");
            }
        }
    }
}