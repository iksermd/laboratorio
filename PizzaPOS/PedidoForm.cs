using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaPOS
{
    public partial class PedidoForm : Form
    {
        public PedidoForm(string _token, int IdPedido = 0)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
        }

        private void PedidoForm_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
