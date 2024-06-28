using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace amen
{
    internal class ProductoData
    {
        private string connectionString = @"Server=DESKTOP-O502RPU\SQLEXPRESS;Database=integracion;Integrated Security=True;";


        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();
            string query = "SELECT id, nombre, precio, stock FROM dbo.productos";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                try
                {
                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Producto producto = new Producto
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Precio = reader.GetInt32(2),
                                Stock = reader.GetInt32(3)
                            };
                            productos.Add(producto);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return productos;
        }

        public void AddProducto(Producto producto)
        {
            string query = "INSERT INTO dbo.productos (nombre, precio, stock) VALUES (@nombre, @precio, @stock)";
            
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);
                
                try
                {
                    conexion.Open();
                    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateProducto(Producto producto)
        {
            string query = "UPDATE dbo.productos SET nombre = @nombre, precio = @precio, stock = @stock WHERE id = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@stock", producto.Stock);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteProducto(int id)
        {
            string query = "DELETE FROM dbo.productos WHERE id = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }



        public void VenderProducto(int id, int cantidad)
        {
            string querySelect = "SELECT stock FROM dbo.productos WHERE id = @id";
            string queryUpdate = "UPDATE dbo.productos SET stock = stock - @cantidad WHERE id = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                SqlCommand cmdSelect = new SqlCommand(querySelect, conexion);
                cmdSelect.Parameters.AddWithValue("@id", id);

                try
                {
                    conexion.Open();
                    int stockActual = (int)cmdSelect.ExecuteScalar();

                    if (stockActual >= cantidad)
                    {
                        SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexion);
                        cmdUpdate.Parameters.AddWithValue("@cantidad", cantidad);
                        cmdUpdate.Parameters.AddWithValue("@id", id);

                        cmdUpdate.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("No hay suficiente stock para realizar la venta.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    MessageBox.Show("Error al realizar la venta: " + ex.Message);
                }
            }
        }

    }
}
