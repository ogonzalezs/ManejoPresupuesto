﻿using Dapper;
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
                                                    (@"INSERT INTO tbl_TiposCuentas (Nombre, UsuarioId, Orden)
                                                    VALUES (@Nombre, @UsuarioId, 0);
                                                    SELECT SCOPE_IDENTITY();", tipoCuenta);

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
            return await connection.QueryAsync<TipoCuenta>("SELECT UsuarioId, Nombre, Orden FROM tbl_TiposCuentas WHERE UsuarioId = @UsuarioId", 
                                                            new {usuarioId});
        }

        public async Task Actualizar(TipoCuenta tipoCuenta) 
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(@"UPDATE tbl_TiposCuentas SET Nombre = @Nombre WHERE TipoCuentaId = @TipoCuentaId", tipoCuenta);
        }
    }
}
