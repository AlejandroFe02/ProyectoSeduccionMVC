using System.ComponentModel.DataAnnotations;

namespace ProyectoProg1.Models
{
    public class Ropa
    {
        [Required(ErrorMessage = "Escribe el codigo del producto")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Escribe el nombre del producto")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Escribe ID del Distribuidor")]
        public int IdDistribuidor { get; set; }
        [Required(ErrorMessage = "Escribe la marca del producto")]
        public string Marca { get; set; }
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Escribe el stock del producto")]

        public int Stock { get; set; }
        [Required(ErrorMessage = "Escribe el precio por docena del producto")]

        public decimal PrecioDocena { get; set; }
        [Required(ErrorMessage = "Escribe el precio por unidad del producto")]
        public decimal PrecioVentaUnid { get; set; }
    }
}