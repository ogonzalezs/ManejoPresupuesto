using Dapper;
using ManejoPresupuesto.Interfaces;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly string connectionString;
        public RepositorioCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task Crear(Cuenta cuenta) 
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(
                @"INSERT INTO tbl_Cuentas(Nombre, TipoCuentaId,Descripcion, Balance)
                VALUES (@Nombre, @TipoCuentaId, @Descripcion, @Balance);
                
                SELECT SCOPE_IDENTITY();", cuenta);

            cuenta.CuentaId = id;
        }
        public async Task<IEnumerable<Cuenta>> Buscar(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Cuenta>(@"SELECT C.CuentaId, C.Nombre, C.Balance, TC.Nombre as TipoCuenta
                    FROM [tbl_Cuentas] C
                    JOIN [tbl_TiposCuentas] TC ON C.TipoCuentaId = TC.TipoCuentaId
                    WHERE   TC.UsuarioId = @UsuarioId", new {usuarioId });
        }

        public async Task<Cuenta> ObtenerPorId(int cuentaId, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cuenta>(
                    @"SELECT C.CuentaId, C.Nombre, C.Balance, TC.TipoCuentaId
                    FROM [tbl_Cuentas] C
                    JOIN [tbl_TiposCuentas] TC ON C.TipoCuentaId = TC.TipoCuentaId
                    WHERE  C.CuentaId = @CuentaId AND TC.UsuarioId = @UsuarioId", new { cuentaId, usuarioId});
        }


        public async Task Actualizar(CuentaCreacionVM cuenta)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"UPDATE [tbl_Cuentas]
                                        SET Nombre = @Nombre, Balance = @Balance, Descripcion = @Descripcion, 
                                        TipoCuentaId = @TipoCuentaId 
                                        WHERE CuentaId = @CuentaId", cuenta);
        }

        public async Task Borrar(int cuentaId)
        {
            var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"DELETE [tbl_Cuentas]
                                        WHERE CuentaId = @CuentaId", new { cuentaId } );

        }
    }
}
