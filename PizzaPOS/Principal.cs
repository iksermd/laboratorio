using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FormsApp
{
    public partial class Principal : Form
    {
        private readonly string _token;

        public Principal(string token)
        {
            InitializeComponent();
            _token = token;

        }
    }
}
