using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoProg1.Models;


namespace ProyectoProg1.Controllers
{
    public class DistribuidorController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5137/api");
        private readonly HttpClient _cliente;
        public DistribuidorController()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }
        // GET: DistribuidorController
        [HttpGet]
        public IActionResult Index()
        {
            List<Distribuidor> ListaVendedores = new List<Distribuidor>();
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Distribuidor").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                ListaVendedores = JsonConvert.DeserializeObject<List<Distribuidor>>(data);
            }
            return View(ListaVendedores);
        }

        // GET: DistribuidorController/Details/5
        public IActionResult Details(int IdDistribuidor)
        {
            Distribuidor vendedor;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Distribuidor/" + IdDistribuidor).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                vendedor = JsonConvert.DeserializeObject<Distribuidor>(data);
                return View(vendedor);

            }
            return RedirectToAction("Index");
        }

        // GET: DistribuidorController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DistribuidorController/Create
        [HttpPost]
        public IActionResult Create(Distribuidor vendedor)
        {
            HttpResponseMessage respone = _cliente.PostAsJsonAsync(_cliente.BaseAddress + "/Distribuidor", vendedor).Result;
            return RedirectToAction("Index");
        }

        // GET: DistribuidorController/Edit/5
        public async Task<IActionResult> Edit(int IdDistribuidor)
        {
            Distribuidor nuevo = await _cliente.GetFromJsonAsync<Distribuidor>(_cliente.BaseAddress + "/Distribuidor/" + IdDistribuidor);
            if (nuevo != null)
            {

                return View(nuevo);
            }
            return RedirectToAction("Index");
        }

        // POST: DistribuidorController/Edit/5
        [HttpPost]
        public IActionResult Edit(Distribuidor vendedor)
        {
            HttpResponseMessage respone = _cliente.PutAsJsonAsync(_cliente.BaseAddress + "/Distribuidor/" + vendedor.IdDistribuidor, vendedor).Result;
            return RedirectToAction("Index");
        }

        // GET: DistribuidorController/Delete/5

        public IActionResult Delete(int IdDistribuidor)
        {
            HttpResponseMessage respone = _cliente.DeleteAsync(_cliente.BaseAddress + "/Distribuidor/" + IdDistribuidor).Result;
            return RedirectToAction("Index");
        }
    }
}