namespace ManejoPresupuesto.Models
{
    public class TransaccionActualizacionVM : TransaccionCreacionVM
    {
        public int CuentaAnteriorId { get; set; }

        public decimal MontoAnterior { get; set; }
    }
}
