using FormsApp;
using Newtonsoft.Json;
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
    public partial class Registrarse : Form
    {
        private readonly string apiUrl;
        public Registrarse()
        {
            InitializeComponent();
            apiUrl = Program.Configuration["ApiSettings:BaseUrl"] + "Auth/registrar";
        }
        public void linkLblLogin_LinkClicked(object sender, EventArgs e)
        {

            //this.Close();
            this.Hide();
            Login mainForm = new Login();
            mainForm.Show();
        }

        private async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string name = txtNombre.Text;
            string username = txtUsuario.Text;
            string password = txtContrasena.Text;


            var loginData = new
            {
                Nombre = name,
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
                        if (jsonResponse != null && jsonResponse.success == 1)
                        {
                            string token = jsonResponse.token;

                            MessageBox.Show("Usuario registrado exitosamente.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
