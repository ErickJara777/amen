using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amen
{
    public partial class Form1 : Form
    {
        private ProductoData productoData = new ProductoData();

        public Form1()
        {
            InitializeComponent();
            LoadProductos();
        }

        private void LoadProductos()
        {
            List<Producto> productos = productoData.GetProductos();
            dataGridProductos.DataSource = productos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Producto producto = new Producto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = int.Parse(txtPrecio.Text),
                Stock = int.Parse(textBox2.Text)
            };
            
            productoData.AddProducto(producto);
            LoadProductos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Precio = int.Parse(txtPrecio.Text),
                Stock = int.Parse(textBox2.Text)
            };

            productoData.UpdateProducto(producto);
            LoadProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            productoData.DeleteProducto(id);
            LoadProductos();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStock.Text);
            int cantidad = int.Parse(textBox1.Text);
            productoData.VenderProducto(id, cantidad);
            LoadProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

