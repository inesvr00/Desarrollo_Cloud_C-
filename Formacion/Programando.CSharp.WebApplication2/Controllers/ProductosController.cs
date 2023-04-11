using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programando.CSharp.WebApplication2.Model;

namespace Programando.CSharp.WebApplication2.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ModelNorthwind _context;

        public ProductosController(ModelNorthwind context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var productos = _context.Products
                .Include(r => r.Category)
                .ToList();

            return View(productos);
        }
    }
}