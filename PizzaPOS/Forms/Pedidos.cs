using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using PizzaPOS.Models;
using PizzaPOS;
using System.Net.Http;

namespace FormsApp
{
    public partial class Pedidos : Form
    {
        private readonly string _token;
        private readonly string apiUrl;
        private List<PedidoModel> pedidos;
        public Pedidos(string token)
        {
            InitializeComponent();
            _token = token;
            apiUrl = Program.Configuration["ApiSettings:BaseUrl"] + "Pedidos";
            LoadPedidos();

        }
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            LoadPedidos();
        }

        private async void LoadPedidos()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    pedidos = JsonConvert.DeserializeObject<List<PedidoModel>>(result);
                    dataGridView1.DataSource = pedidos;
                }
                else
                {
                    MessageBox.Show("Error al cargar los pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PedidoDetalleForm pedidoForm = new PedidoDetalleForm(_token);
            pedidoForm.FormClosed += (s, args) => LoadPedidos();
            pedidoForm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el pedido seleccionado desde el DataGridView
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedPedido = (PedidoModel)selectedRow.DataBoundItem;

                if (selectedPedido != null)
                {
                    EliminarPedido(selectedPedido.Id);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido para eliminar.");
            }
        }


        private async void EliminarPedido(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pedido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPedidos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener el pedido seleccionado desde el DataGridView
                var selectedRow = dataGridView1.SelectedRows[0];
                var selectedPedido = (PedidoModel)selectedRow.DataBoundItem;

                if (selectedPedido != null)
                {
                    // Abrir el formulario de edición
                    PedidoDetalleForm pedidoForm = new PedidoDetalleForm(_token, selectedPedido.Id);
                    pedidoForm.FormClosed += (s, args) => LoadPedidos(); // Recargar la tabla después de cerrar el formulario
                    pedidoForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un pedido para editar.");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void crearPedido_Click(object sender, EventArgs e)
        {
            PedidoDetalleForm pedidoForm = new PedidoDetalleForm(_token);

            // Configurar el formulario secundario para que no tenga bordes y no sea de nivel superior
            pedidoForm.FormBorderStyle = FormBorderStyle.None;
            pedidoForm.TopLevel = false;
            pedidoForm.Dock = DockStyle.Fill;

            // Limpiar cualquier control existente en el Panel y agregar el formulario secundario
            //this.panel1.Controls.Clear();
            this.panel1.Controls.Add(pedidoForm);
            pedidoForm.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
