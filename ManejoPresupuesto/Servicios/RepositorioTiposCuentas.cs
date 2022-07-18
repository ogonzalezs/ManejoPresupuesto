using Dapper;
using ManejoPresupuesto.Interfaces;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;
        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta) 
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>
                                                    ("TiposCuentas_Insertar", 
                                                    new { usuarioId = tipoCuenta.UsuarioId,
                                                    nombre = tipoCuenta.Nombre },
                                                    commandType: System.Data.CommandType.StoredProcedure);

            tipoCuenta.TipoCuentaId = id;
        }

        public async Task<bool> Existe(string nombre, int usuarioId) 
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>
                                                    (@"SELECT 1 FROM tbl_TiposCuentas WHERE Nombre = @Nombre AND UsuarioId = @UsuarioId;",
                                                    new {nombre, usuarioId});

            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId) 
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TipoCuenta>("SELECT TipoCuentaId, UsuarioId, Nombre, Orden FROM tbl_TiposCuentas WHERE UsuarioId = @UsuarioId ORDER BY ORDEN", 
                                                            new {usuarioId});
        }

        public async Task Actualizar(TipoCuenta tipoCuenta) 
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"UPDATE tbl_TiposCuentas SET Nombre = @Nombre WHERE TipoCuentaId = @TipoCuentaId", tipoCuenta);
        }

        public async Task<TipoCuenta> ObtenerPorId(int tipoCuentaId, int usuarioId) 
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<TipoCuenta>
                                    (@"SELECT TipoCuentaId, UsuarioId, Nombre, Orden from tbl_TiposCuentas 
                                    WHERE TipoCuentaId = @TipoCuentaId AND UsuarioId = @UsuarioId", new { tipoCuentaId, usuarioId });

        }

        public async Task Borrar (int tipoCuentaId) 
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("DELETE tbl_TiposCuentas WHERE TipoCuentaId = @TipoCuentaId", new { tipoCuentaId });
        }

        public async Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados) 
        {
            var query = "UPDATE tbl_TiposCuentas SET Orden = @Orden WHERE TipoCuentaId = @TipoCuentaId;";
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, tipoCuentasOrdenados);
        }
    }
}
