using System;

namespace amen
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, int precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
