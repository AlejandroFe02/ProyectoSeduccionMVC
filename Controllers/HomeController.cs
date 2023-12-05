using Microsoft.AspNetCore.Mvc;
using ProyectoProg1.Models;
using System.Diagnostics;

namespace ProyectoProg1.Controllers
{
    public class HomeController : Controller


    {
        private readonly ILogger<HomeController> _logger;

        Uri baseAddress = new Uri("http://localhost:5137/api");
        private readonly HttpClient _cliente;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index()
        {
            List<Pedido> pedidots = new List<Pedido>();
            pedidots = await _cliente.GetFromJsonAsync<List<Pedido>>(_cliente.BaseAddress + "/Pedido");

            return View(pedidots);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}