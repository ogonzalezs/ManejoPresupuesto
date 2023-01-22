using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Interfaces
{
    public interface IRepositorioCategorias
    {
        Task Crear(Categoria categoria);
    }
}
