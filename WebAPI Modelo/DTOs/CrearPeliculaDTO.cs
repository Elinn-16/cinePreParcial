namespace WebAPI_Modelo.DTOs
{
    public class CrearPeliculaDTO
    {
        public string Titulo { get; set; } = null!;

        public string Director { get; set; } = null!;
        public int Anio { get; set; }
        public bool Estreno { get; set; } = true;
        public int IdGenero { get; set; }
    }
}
