using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PizzaPOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Login : Form
    {
        private readonly string apiUrl;
        public Login()
        {
            InitializeComponent();
            apiUrl = Program.Configuration["ApiSettings:BaseUrl"] + "Auth/login";
        }

        private void linkLblRegistrarse_LinkClicked(object sender, EventArgs e)
        {
            this.Hide();
            Registrarse mainForm = new Registrarse();
            mainForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContrasena.Text;

            var loginData = new
            {
                Correo = username,
                Contrasena = password
            };

            string json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                        if (jsonResponse != null && jsonResponse.success==1) { 
                            string token = jsonResponse.token;

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Pedidos mainForm = new Pedidos(token);
                            mainForm.Show();
                        }
                        else
                        {
                            lblMensaje.Text = jsonResponse.message;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Error al iniciar sesión";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en la solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
