using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoProg1.Models;

namespace ProyectoProg1.Controllers
{
    public class PedidoController : Controller
    {

        Uri baseAddress = new Uri("http://localhost:5137/api");
        private readonly HttpClient _cliente;
        public PedidoController()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }

        // GET: PedidoController
        [HttpGet]
        public IActionResult Index()
        {
            List<Pedido> ListaProductos = new List<Pedido>();
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Pedido").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                ListaProductos = JsonConvert.DeserializeObject<List<Pedido>>(data);
            }
            return View(ListaProductos);
        }

        public IActionResult Filtro()
        {
            return View();
        }

        // GET: PedidoController/Details/5
        public IActionResult Details(string PedidoId)
        {
            Pedido p;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Pedido/" + PedidoId).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Pedido>(data);
                return View(p);

            }
            return RedirectToAction("Index");
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        public IActionResult Create(Pedido producto)
        {
            HttpResponseMessage respone = _cliente.PostAsJsonAsync(_cliente.BaseAddress + "/Pedido", producto).Result;
            return RedirectToAction("Index");
        }

        // GET: PedidoController/Edit/5
        public async Task<IActionResult> Edit(string PedidoId)
        {
            Pedido nuevo = await _cliente.GetFromJsonAsync<Pedido>(_cliente.BaseAddress + "/Pedido/" + PedidoId);
            if (nuevo != null)
            {

                return View(nuevo);
            }
            return RedirectToAction("Index");
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        public IActionResult Edit(Pedido producto)
        {
            HttpResponseMessage respone = _cliente.PutAsJsonAsync(_cliente.BaseAddress + "/Pedido/" + producto.PedidoId, producto).Result;
            return RedirectToAction("Index");
        }

        // GET: PedidoController/Delete/5
        public IActionResult Delete(string PedidoId)
        {
            HttpResponseMessage respone = _cliente.DeleteAsync(_cliente.BaseAddress + "/Pedido/" + PedidoId).Result;
            return RedirectToAction("Index");
        }

    }
}