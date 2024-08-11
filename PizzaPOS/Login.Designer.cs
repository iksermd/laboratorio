namespace FormsApp
{
    partial class Login
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
            label1 = new Label();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            btnLogin = new Button();
            label2 = new Label();
            label3 = new Label();
            lblMensaje = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(283, 91);
            label1.Name = "label1";
            label1.Size = new Size(216, 54);
            label1.TabIndex = 3;
            label1.Text = "Forms App";
            label1.Click += label1_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(185, 243);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(400, 39);
            txtUsuario.TabIndex = 4;
            txtUsuario.TextChanged += textBox1_TextChanged;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(185, 339);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(400, 39);
            txtContrasena.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(185, 525);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 46);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(185, 199);
            label2.Name = "label2";
            label2.Size = new Size(94, 32);
            label2.TabIndex = 7;
            label2.Text = "Usuario";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 304);
            label3.Name = "label3";
            label3.Size = new Size(134, 32);
            label3.TabIndex = 8;
            label3.Text = "Contraseña";
            // 
            // lblMensaje
            // 
            lblMensaje.AutoSize = true;
            lblMensaje.ForeColor = Color.Crimson;
            lblMensaje.Location = new Point(185, 416);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(0, 32);
            lblMensaje.TabIndex = 9;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 877);
            Controls.Add(lblMensaje);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnLogin);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private Button btnLogin;
        private Label label2;
        private Label label3;
        private Label lblMensaje;
    }
}