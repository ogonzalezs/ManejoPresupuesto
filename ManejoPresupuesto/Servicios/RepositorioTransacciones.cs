using Dapper;
using ManejoPresupuesto.Interfaces;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioTransacciones : IRepositorioTransacciones
    {
        private readonly string connectionString;
        public RepositorioTransacciones(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Transaccion transaccion) 
        { 
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>("Transacciones_Insertar",
                        new
                        {
                            transaccion.UsuarioId,
                            transaccion.FechaTransaccion,
                            transaccion.Monto,
                            transaccion.CategoriaId,
                            transaccion.CuentaId,
                            transaccion.Nota
                        },
                        commandType: System.Data.CommandType.StoredProcedure);

            transaccion.TransaccionId = id;
        }

        public async Task Actualizar(Transaccion transaccion, decimal montoAnterior, int cuentaAnteriorId) 
        { 
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("Transacciones_Actualizar",
                new
                {
                    transaccion.TransaccionId,
                    transaccion.FechaTransaccion,
                    transaccion.Monto,
                    transaccion.CategoriaId,
                    transaccion.CuentaId,
                    transaccion.Nota,
                    montoAnterior,
                    cuentaAnteriorId
                }, commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Transaccion> ObtenerPorId(int transaccionId, int usuarioId) 
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Transaccion>(
                @"SELECT t.*, c.TipoOperacionId
                    FROM tbl_Transacciones t
                    JOIN tbl_Categorias c ON c.CategoriaId = t.CategoriaId
                    WHERE t.TransaccionId = @transaccionId AND t.UsuarioId = @usuarioId",
                new { transaccionId, usuarioId });
        }
    }
}
