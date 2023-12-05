using Microsoft.AspNetCore.Mvc;
using ProyectoProg1.Models;
using System;
using System.Collections.Generic;

namespace ProyectoProg1.Controllers
{
    public class ComentarioController : Controller
    {
        // Acción para mostrar un comentario específico
        public IActionResult Detalles(int id)
        {
            // Aquí debes obtener el comentario con el ID proporcionado desde tu fuente de datos
            Comentario comentario = ObtenerComentarioPorId(id);

            if (comentario == null)
            {
                return NotFound(); // Comentario no encontrado
            }

            return View(comentario);
        }


        // Acción para mostrar todos los comentarios
        public IActionResult Lista()
        {
            List<ProyectoProg1.Models.Comentario> comentarios = ObtenerTodosLosComentarios();
            return View("Lista", comentarios);
        }

        public IActionResult Eliminar(int id)
        {
            // Aquí debes implementar la lógica para eliminar el comentario con el ID proporcionado
            // Por ahora, simplemente redirigimos a la lista de comentarios después de eliminar
            // Puedes mostrar un mensaje de éxito si lo deseas
            // ...

            // Redirigir a la lista después de eliminar
            return RedirectToAction("Lista");
        }





        // Método de ejemplo para obtener un comentario por ID (simula la obtención desde una base de datos)
        private Comentario ObtenerComentarioPorId(int id)
        {
            // Deberías implementar lógica para obtener el comentario desde tu fuente de datos (base de datos, servicio, etc.)
            // Por ahora, simplemente devolvemos un comentario de ejemplo
            return new Comentario
            {
                IdComentario = id,
                CedulaAutor = "1234567890",
                NombreAutor = "Nombre del Autor",
                Mensaje = "Este es un comentario de ejemplo.",
                Fecha = DateTime.Now
            };
        }

        // Método de ejemplo para obtener todos los comentarios (simula la obtención desde una base de datos)
        private List<Comentario> ObtenerTodosLosComentarios()
        {
            // Deberías implementar lógica para obtener todos los comentarios desde tu fuente de datos (base de datos, servicio, etc.)
            // Por ahora, simplemente devolvemos una lista de comentarios de ejemplo
            return new List<Comentario>
            {
                new Comentario
                {
                    IdComentario = 1,
                    CedulaAutor = "1234567890",
                    NombreAutor = "Nombre del Autor 1",
                    Mensaje = "Este es un comentario de ejemplo 1.",
                    Fecha = DateTime.Now
                },
                new Comentario
                {
                    IdComentario = 2,
                    CedulaAutor = "0987654321",
                    NombreAutor = "Nombre del Autor 2",
                    Mensaje = "Este es un comentario de ejemplo 2.",
                    Fecha = DateTime.Now.AddHours(-1)
                },
                // Agregar más comentarios según sea necesario
            };
        }
    }
}
