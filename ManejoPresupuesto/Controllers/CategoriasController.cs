using ManejoPresupuesto.Interfaces;
using ManejoPresupuesto.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManejoPresupuesto.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly IRepositorioCategorias repositorioCategorias;
        private readonly IServicioUsuario servicioUsuario;

        public CategoriasController(IRepositorioCategorias repositorioCategorias, 
                                    IServicioUsuario servicioUsuario)
        {
            this.repositorioCategorias = repositorioCategorias;
            this.servicioUsuario = servicioUsuario;
        }

        public async Task<IActionResult> Index () 
        {
            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var categorias = await repositorioCategorias.Obtener(usuarioId);
            return View(categorias);
        }

        [HttpGet]
        public IActionResult Crear() 
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Crear (Categoria categoria) 
        {
            if (!ModelState.IsValid)
            {
                return View(categoria);
            }

            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            categoria.UsuarioId = usuarioId;
            await repositorioCategorias.Crear(categoria);
            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> Editar (int id) 
        {
            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var categoria = await repositorioCategorias.ObtenerPorId(id, usuarioId);

            if (categoria is null)
            {
                return RedirectToAction("No Encontrado", "Index");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Categoria categoriaEditar) 
        {
            if (!ModelState.IsValid)
            {
                return View(categoriaEditar);
            }

            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var categoria = await repositorioCategorias.ObtenerPorId(categoriaEditar.CategoriaId, usuarioId);

            if (categoria is null)
            {
                return RedirectToAction("No Encontrado", "Index");
            }

            categoriaEditar.UsuarioId = usuarioId;
            await repositorioCategorias.Actualizar(categoriaEditar);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Borrar (int id) 
        {
            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var categoria = await repositorioCategorias.ObtenerPorId(id, usuarioId);

            if (categoria is null)
            {
                return RedirectToAction("No Encontrado", "Index");
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarCategoria (int categoriaId)
        {
            var usuarioId = servicioUsuario.ObtenerUsuarioId();
            var categoria = await repositorioCategorias.ObtenerPorId(categoriaId, usuarioId);

            if (categoria is null)
            {
                return RedirectToAction("No Encontrado", "Index");
            }

            await repositorioCategorias.Borrar(categoriaId);
            return RedirectToAction("Index");
        }

    }
}
