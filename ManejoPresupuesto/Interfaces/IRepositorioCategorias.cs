using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Interfaces
{
    public interface IRepositorioCategorias
    {
        Task Actualizar(Categoria categoria);
        Task Borrar(int categoriaId);
        Task Crear(Categoria categoria);
        Task<IEnumerable<Categoria>> Obtener(int usuarioId);
        Task<IEnumerable<Categoria>> Obtener(int usuarioId, TipoOperacion tipoOperacion);
        Task<Categoria> ObtenerPorId(int id, int usuarioId);
    }
}
