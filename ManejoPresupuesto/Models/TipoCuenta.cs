using ManejoPresupuesto.Validaciones;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoPresupuesto.Models
{
    public class TipoCuenta //: IValidatableObject
    {
        public int TipoCuentaId { get; set; }
        
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [PrimeraLetraMayuscula]
        [Remote(action: "VerificarExisteTipoCuenta", controller: "TiposCuentas")]
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int Orden { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Nombre != null && Nombre.Length > 0)
        //    {
        //        var primerlaLetra = Nombre[0].ToString();

        //        if(primerlaLetra != primerlaLetra.ToUpper()) 
        //        {
        //            yield return new ValidationResult("La primera letra debe ser mayúscula." , 
        //                new[] {nameof(Nombre)});

        //        }
        //    }
        //}
    }
}
