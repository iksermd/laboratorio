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

namespace FormsApp
{
    public partial class Principal : Form
    {
        private readonly string _token;
        private readonly string apiUrl;
        private List<PedidoModel> pedidos;
        public Principal(string token)
        {
            InitializeComponent();
            _token = token;
            apiUrl = Program.Configuration["ApiSettings:BaseUrl"] + "Pedidos";
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
                    lstPedidos.DataSource = pedidos;
                }
                else
                {
                    MessageBox.Show("Error al cargar los pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            PedidoForm pedidoForm = new PedidoForm(_token);
            pedidoForm.FormClosed += (s, args) => LoadPedidos();
            pedidoForm.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var selectedPedido = (PedidoModel)lstPedidos.SelectedItem;
            if (selectedPedido != null)
            {
                EliminarPedido(selectedPedido.Id);
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
            var selectedPedido = (PedidoModel)lstPedidos.SelectedItem;
            if (selectedPedido != null)
            {
                PedidoForm pedidoForm = new PedidoForm(_token, selectedPedido.Id);
                pedidoForm.FormClosed += (s, args) => LoadPedidos();
                pedidoForm.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
