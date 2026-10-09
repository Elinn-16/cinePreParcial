using WebAPI_Modelo.Models;
using WebAPI_Modelo.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI_Modelo.Services
{
    public interface ICineServicio
    {
        Task<List<PeliculasCarteleraDTO>> ObtenerPeliculasEnEstrenoAsync();
        Task<DetallePeliculaDTO> CrearPeliculaAsync(CrearPeliculaDTO dto);
        Task<bool> ActualizarPeliculaAsync(int id);
        
    }
}
