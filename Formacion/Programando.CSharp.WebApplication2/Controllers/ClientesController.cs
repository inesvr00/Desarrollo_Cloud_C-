using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication2.Model;

namespace Programando.CSharp.WebApplication2.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ModelNorthwind _context;
        private readonly HttpClient _http;

        public ClientesController(ModelNorthwind context, HttpClient http)
        {
            _context = context;
            _http = http;
        }

        public IActionResult Index()
        {
            var clientes = _context.Customers.ToList();

            return View(clientes);
        }

        public IActionResult Index2()
        {
            var clientes = _http.GetFromJsonAsync<List<Customer>>("http://localhost:5034/api/");

            return View(clientes);
        }
    }
}
