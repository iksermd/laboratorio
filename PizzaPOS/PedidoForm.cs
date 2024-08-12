using FormsApp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaPOS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaPOS
{
    public partial class PedidoForm : Form
    {
        private bool modoEdicion = false;
        private string _token;
        private readonly string apiUrl;
        private readonly int IdPedido;
        private int eliminarColumnIndex;
        public PedidoForm(string token, int idPedido = 0)
        {
            _token = token;
            apiUrl = Program.Configuration["ApiSettings:BaseUrl"] + "PedidoDetalles/";
            IdPedido = idPedido;

            InitializeComponent();
            if (dataGridView1.Rows.Count > 0)
                eliminarColumnIndex = dataGridView1.Columns["btnEliminar"].Index;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;

        }
        private void PedidoForm_Load(object sender, EventArgs e)
        {
            if (IdPedido > 0)
            {
                LoadPedidoDetalles();
            }
            int eliminarColumnIndex = dataGridView1.Columns["btnEliminar"].Index;
        }
        private async void LoadPedidoDetalles()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                HttpResponseMessage response = await client.GetAsync(apiUrl + IdPedido);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var pedidoDetalles = JsonConvert.DeserializeObject<List<PedidoDetalleModel>>(result);
                    dataGridView1.DataSource = pedidoDetalles;
                }
                else
                {
                    MessageBox.Show("Error al cargar los detalles del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void EliminarDetallePedido(int detalleId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                HttpResponseMessage response = await client.DeleteAsync(apiUrl + IdPedido);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Detalle del pedido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Recargar los detalles después de la eliminación
                    LoadPedidoDetalles();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el detalle del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridView1.Rows[e.RowIndex];
            var detallePedido = (PedidoDetalleModel)selectedRow.DataBoundItem;

            if (detallePedido != null)
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                    var content = new StringContent(JsonConvert.SerializeObject(detallePedido), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(apiUrl + IdPedido, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Error al actualizar la cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == eliminarColumnIndex && e.RowIndex>0) // eliminarColumnIndex debe ser el índice de la columna con el botón de eliminar
            {
                var selectedRow = dataGridView1.Rows[e.RowIndex];
                var detallePedido = (PedidoDetalleModel)selectedRow.DataBoundItem;

                if (detallePedido != null)
                {
                    EliminarDetallePedido(detallePedido.Id);
                }
            }
        }

    }
}
