namespace ProyectoProg1.Models
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string CedulaAutor { get; set;}
        public string NombreAutor { get; set; }
        public string Mensaje { get; set;}
        public DateTime Fecha { get; set;}
    }
}
