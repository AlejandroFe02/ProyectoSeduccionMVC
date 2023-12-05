using System.ComponentModel.DataAnnotations;

namespace ProyectoProg1.Models
{
    public class Distribuidor
    {
        public int IdDistribuidor { get; set; }

        [Required(ErrorMessage = "Escribe el nombre del producto")]
        public string Nombre { get; set; }
        public string Marca { get; set; }
        [Required(ErrorMessage = "Escribe el numero de telefono del distribuidor")]
        public string Contacto { get; set; }
        public int NumeroCompra { get; set; }
    }
}