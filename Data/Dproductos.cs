using APIsinPlantilla.Connection;
using APIsinPlantilla.Models;
using System.Data;
using System.Data.SqlClient;

namespace APIsinPlantilla.Data
{
    public class Dproductos
    {
        //Se crea la conexion
        DBConnection connection = new DBConnection();
        public async Task <List<Mproductos>> mostrarProductos()
        {
            var listaProductos = new List<Mproductos>();
            
            /*Se abre la conexion con la lista*/
            using (var sql = new SqlConnection(connection.cadenaSQL())) 
            {
                /*Se "declara" la conexion a la base de 
                 *datos que se desea conectar para usar proc almacenados*/
                using (var cmd = new SqlCommand("mostrarProductos", sql)) 
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while(await item.ReadAsync()) 
                        {
                            var Dproductos = new Mproductos();
                            Dproductos.id = (int)item["id"];
                            Dproductos.descripcion = (string)item["descripcion"];
                            Dproductos.precio = (decimal)item["precio"];
                            listaProductos.Add(Dproductos);
                        }
                    }
                }
            }

            return listaProductos;
        }

        public async Task insertarProductos(Mproductos parametros)
        { 
            using (var sql = new SqlConnection(connection.cadenaSQL())) 
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task editarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(connection.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task eliminarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(connection.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
