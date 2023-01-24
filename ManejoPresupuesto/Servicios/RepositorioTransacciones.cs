﻿using Dapper;
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
    }
}