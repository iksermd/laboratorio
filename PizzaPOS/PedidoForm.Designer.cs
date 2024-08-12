namespace PizzaPOS
{
    partial class PedidoForm
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
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            FechaCreacion = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // Suscribir eventos
            this.Load += PedidoForm_Load;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Cliente, FechaCreacion });
            dataGridView1.Location = new Point(31, 130);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1730, 760);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.MinimumWidth = 10;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 200;
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente";
            Cliente.MinimumWidth = 10;
            Cliente.Name = "Cliente";
            Cliente.ReadOnly = true;
            Cliente.Width = 200;
            // 
            // FechaCreacion
            // 
            FechaCreacion.HeaderText = "Fecha Creacion";
            FechaCreacion.MinimumWidth = 10;
            FechaCreacion.Name = "FechaCreacion";
            FechaCreacion.ReadOnly = true;
            FechaCreacion.Width = 200;
            //
            //BotonEliminar
            //
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btnEliminar);

            // 
            // PedidoForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1869, 988);
            Controls.Add(dataGridView1);
            Name = "PedidoForm";
            Text = "PedidoForm";
            Load += PedidoForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);


        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn FechaCreacion;

    }
}