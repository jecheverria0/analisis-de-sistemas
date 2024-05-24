using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaContable.Conexion;
using SistemaContable.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SistemaContable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaseDatos _baseDatos;

        public HomeController(ILogger<HomeController> logger, BaseDatos baseDatos)
        {
            _logger = logger;
            _baseDatos = baseDatos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cuentas()
        {
            var cuentas = _baseDatos.ConsultaCuenta();
            return View(cuentas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CuentaId,Numcuenta,TipoCuenta,Tipomoneda,MontoApertura,Banco")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                // Aquí podrías agregar código para guardar la nueva cuenta en la base de datos usando BaseDatos
                return RedirectToAction(nameof(Index));
            }
            return View(cuenta);
        }

        public IActionResult Edit(int id)
        {
            var cuenta = _baseDatos.ConsultaCuenta().FirstOrDefault(c => c.CuentaId == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return View(cuenta);
        }

        public IActionResult Delete(int id)
        {
            var cuenta = _baseDatos.ConsultaCuenta().FirstOrDefault(c => c.CuentaId == id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return View(cuenta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Aquí podrías agregar código para eliminar la cuenta de la base de datos usando BaseDatos
            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        public IActionResult BuscarCuenta(int cuentaId, string accion)
        {
            var cuenta = _baseDatos.ConsultaCuenta().FirstOrDefault(c => c.CuentaId == cuentaId);
            if (cuenta == null)
            {
                return NotFound();
            }

            if (accion == "Edit")
            {
                return RedirectToAction("Edit", new { id = cuentaId });
            }
            else if (accion == "Delete")
            {
                return RedirectToAction("Delete", new { id = cuentaId });
            }

            return NotFound();
        }
    }
}