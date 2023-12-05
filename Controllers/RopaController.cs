using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoProg1.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProyectoProg1.Controllers
{
    public class RopaController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5137/api");
        private readonly HttpClient _cliente;
        public RopaController()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }
        // GET: RopaController
        [HttpGet]
        public IActionResult Index()
        {
            List<Ropa> ListaProductos = new List<Ropa>();
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                ListaProductos = JsonConvert.DeserializeObject<List<Ropa>>(data);
            }
            return View(ListaProductos);
        }

        // GET: RopaController/Details/5
        public IActionResult Details(string Codigo)
        {
            Ropa p;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa/" + Codigo).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Ropa>(data);
                return View(p);

            }
            return RedirectToAction("Index");
        }

        // GET: RopaController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ropa producto)
        {
            HttpResponseMessage respone = _cliente.PostAsJsonAsync(_cliente.BaseAddress + "/Ropa", producto).Result;
            return RedirectToAction("Index");
        }

        // GET: RopaController/Edit/5
        public async Task<IActionResult> Edit(string Codigo)
        {
            Ropa nuevo = await _cliente.GetFromJsonAsync<Ropa>(_cliente.BaseAddress + "/Ropa/" + Codigo);
            if (nuevo != null)
            {

                return View(nuevo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Ropa producto)
        {
            HttpResponseMessage respone = _cliente.PutAsJsonAsync(_cliente.BaseAddress + "/Ropa/" + producto.Codigo, producto).Result;
            return RedirectToAction("Index");
        }
        // GET: RopaController/Delete/5
        public IActionResult Delete(string Codigo)
        {
            HttpResponseMessage respone = _cliente.DeleteAsync(_cliente.BaseAddress + "/Ropa/" + Codigo).Result;
            return RedirectToAction("Index");
        }
        public IActionResult Precio(string Codigo)
        {
            Ropa p;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa/" + Codigo).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Ropa>(data);
                return View(p);

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult CalcularPrecios(string codigo)
        {
            // Obtener el objeto Ropa según el código proporcionado
            Ropa ropa = ObtenerRopaPorCodigo(codigo);

            if (ropa == null)
            {
                return RedirectToAction("Index");
            }

            // Realizar los cálculos
            decimal ivaPrecioDocena = ropa.PrecioDocena * 0.12m;
            decimal precioDocenaMasIVA = ropa.PrecioDocena + ivaPrecioDocena;
            decimal precioUnitarioMasIVA = ropa.PrecioVentaUnid + ivaPrecioDocena;
            decimal precioUnitarioMas50Porciento = ropa.PrecioVentaUnid + (ropa.PrecioVentaUnid * 0.5m);
            decimal precioUnitarioMas60Porciento = ropa.PrecioVentaUnid + (ropa.PrecioVentaUnid * 0.6m);
            decimal precioVentaPublicoX350Porciento = (ropa.PrecioVentaUnid + (ropa.PrecioVentaUnid * 0.5m)) * 3;
            decimal precioVentaPublicoX360Porciento = (ropa.PrecioVentaUnid + (ropa.PrecioVentaUnid * 0.6m)) * 3;

            // Almacena los resultados en ViewBag
            ViewBag.CalculosRealizados = true;
            ViewBag.IvaPrecioDocena = ivaPrecioDocena;
            ViewBag.PrecioDocenaMasIVA = precioDocenaMasIVA;
            ViewBag.PrecioUnitarioMasIVA = precioUnitarioMasIVA;
            ViewBag.PrecioUnitarioMas50Porciento = precioUnitarioMas50Porciento;
            ViewBag.PrecioUnitarioMas60Porciento = precioUnitarioMas60Porciento;
            ViewBag.PrecioVentaPublicoX350Porciento = precioVentaPublicoX350Porciento;
            ViewBag.PrecioVentaPublicoX360Porciento = precioVentaPublicoX360Porciento;

            // Redirige de vuelta a la vista de precios
            return View("Precio", ropa); // Reemplaza "Precio" por el nombre real de tu vista de precios
        }

        private Ropa ObtenerRopaPorCodigo(string codigo)
        {
            HttpResponseMessage response = _cliente.GetAsync(_cliente.BaseAddress + "/Ropa/" + codigo).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Ropa>(data);
            }
            return null;
        }


    }
}