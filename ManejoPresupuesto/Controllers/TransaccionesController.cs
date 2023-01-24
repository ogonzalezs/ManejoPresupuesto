using ManejoPresupuesto.Interfaces;
using ManejoPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManejoPresupuesto.Controllers
{
    public class TransaccionesController : Controller
    {
        private readonly IServicioUsuario servicioUsuario;
        private readonly IRepositorioCuentas repositorioCuentas;

        public TransaccionesController(IServicioUsuario servicioUsuario
                            , IRepositorioCuentas repositorioCuentas)
        {
            this.servicioUsuario = servicioUsuario;
            this.repositorioCuentas = repositorioCuentas;
        }


        public async Task<IActionResult> Crear() 
        {
            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var modelo = new TransaccionCreacionVM();
            modelo.Cuentas = await ObtenerCuentas(usuarioId);

            return View(modelo);
        }

        private async Task<IEnumerable<SelectListItem>> ObtenerCuentas (int usuarioId) 
        {
            var cuentas = await repositorioCuentas.Buscar(usuarioId);
            return cuentas.Select(x => new SelectListItem(x.Nombre, x.CuentaId.ToString()));
        }
    }
}
