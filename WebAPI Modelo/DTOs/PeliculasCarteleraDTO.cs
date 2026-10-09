namespace WebAPI_Modelo.DTOs
{
    public class PeliculasCarteleraDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Director { get; set; } = null!;
        public int Anio { get; set; }
        public bool Estreno { get; set; } = true;
        public string Genero { get; set; } = null!;
    }
}
