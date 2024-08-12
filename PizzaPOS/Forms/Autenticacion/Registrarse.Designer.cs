namespace PizzaPOS
{
    partial class Registrarse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label3 = new Label();
            label2 = new Label();
            btnRegistrarse = new Button();
            txtContrasena = new TextBox();
            txtUsuario = new TextBox();
            label1 = new Label();
            label4 = new Label();
            txtNombre = new TextBox();
            linkLblLogin = new LinkLabel();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(225, 451);
            label3.Name = "label3";
            label3.Size = new Size(134, 32);
            label3.TabIndex = 14;
            label3.Text = "Contraseña";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(225, 346);
            label2.Name = "label2";
            label2.Size = new Size(211, 32);
            label2.TabIndex = 13;
            label2.Text = "Correo electrónico";
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(225, 670);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(400, 46);
            btnRegistrarse.TabIndex = 12;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(225, 486);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(400, 39);
            txtContrasena.TabIndex = 11;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(225, 390);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(400, 39);
            txtUsuario.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(331, 113);
            label1.Name = "label1";
            label1.Size = new Size(184, 54);
            label1.TabIndex = 9;
            label1.Text = "PizzaPOS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(225, 240);
            label4.Name = "label4";
            label4.Size = new Size(102, 32);
            label4.TabIndex = 16;
            label4.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(225, 284);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(400, 39);
            txtNombre.TabIndex = 15;
            // 
            // linkLblLogin
            // 
            linkLblLogin.AutoSize = true;
            linkLblLogin.Location = new Point(226, 608);
            linkLblLogin.Name = "linkLblLogin";
            linkLblLogin.Size = new Size(151, 32);
            linkLblLogin.TabIndex = 17;
            linkLblLogin.TabStop = true;
            linkLblLogin.Text = "Iniciar sesión";
            linkLblLogin.LinkClicked += linkLblLogin_LinkClicked;
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.Crimson;
            lblMensaje.Location = new Point(226, 542);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 32);
            lblMensaje.TabIndex = 18;
            // 
            // Registrarse
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 844);
            Controls.Add(lblMensaje);
            Controls.Add(linkLblLogin);
            Controls.Add(label4);
            Controls.Add(txtNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Name = "Registrarse";
            Text = "Registrarse";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Button btnRegistrarse;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
        private Label label1;
        private Label label4;
        private TextBox txtNombre;
        private LinkLabel linkLblLogin;
        private Label lblMensaje;
    }
}