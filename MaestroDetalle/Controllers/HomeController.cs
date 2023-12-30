using MaestroDetalle.Models;
using MaestroDetalle.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaestroDetalle.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbcompraContext _dbcompra;

        public HomeController(ILogger<HomeController> logger, DbcompraContext dbcompra)
        {
            _logger = logger;
            _dbcompra = dbcompra;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] CompraVM ObjectCompraVm)
        {
            Compra compra = ObjectCompraVm.CompraObject;
            compra.DetalleCompras = ObjectCompraVm.ListDetalleCompra;

            _dbcompra.Compras.Add(compra);
            _dbcompra.SaveChanges(); 

            return Json( new { Respuesta= "Se creo correctamente el objecto"});

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
