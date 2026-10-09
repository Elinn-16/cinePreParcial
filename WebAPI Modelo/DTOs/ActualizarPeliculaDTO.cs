namespace WebAPI_Modelo.DTOs
{
    public class ActualizarPeliculaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int Anio { get; set; }
        public string IdGenero { get; set; } = null!;
    }
}
