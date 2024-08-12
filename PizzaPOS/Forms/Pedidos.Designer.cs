namespace FormsApp
{
    partial class Pedidos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            brnCrearPedido = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            btnEditarPedido = new Button();
            btnEliminarPedido = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // brnCrearPedido
            // 
            brnCrearPedido.Location = new Point(34, 165);
            brnCrearPedido.Name = "brnCrearPedido";
            brnCrearPedido.Size = new Size(264, 84);
            brnCrearPedido.TabIndex = 1;
            brnCrearPedido.Text = "Crear Pedido";
            brnCrearPedido.UseVisualStyleBackColor = true;
            brnCrearPedido.Click += crearPedido_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(360, 165);
            panel1.Name = "panel1";
            panel1.Size = new Size(2106, 1135);
            panel1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 90);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(2069, 1029);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // btnEditarPedido
            // 
            btnEditarPedido.Location = new Point(34, 274);
            btnEditarPedido.Name = "btnEditarPedido";
            btnEditarPedido.Size = new Size(264, 84);
            btnEditarPedido.TabIndex = 5;
            btnEditarPedido.Text = "Editar Pedido";
            btnEditarPedido.UseVisualStyleBackColor = true;
            btnEditarPedido.Click += btnEditar_Click;
            // 
            // btnEliminarPedido
            // 
            btnEliminarPedido.Location = new Point(34, 385);
            btnEliminarPedido.Name = "btnEliminarPedido";
            btnEliminarPedido.Size = new Size(264, 84);
            btnEliminarPedido.TabIndex = 6;
            btnEliminarPedido.Text = "Eliminar Pedido";
            btnEliminarPedido.UseVisualStyleBackColor = true;
            btnEliminarPedido.Click += btnEliminar_Click;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2501, 1453);
            Controls.Add(btnEliminarPedido);
            Controls.Add(btnEditarPedido);
            Controls.Add(panel1);
            Controls.Add(brnCrearPedido);
            Name = "Principal";
            Text = "Pizza POS";
            Load += FormPrincipal_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
        private Button brnCrearPedido;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button btnEditarPedido;
        private Button btnEliminarPedido;
    }
}
