namespace Visual_WForms
{
    partial class Other
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
            this.gv_table = new System.Windows.Forms.DataGridView();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.txt_estado = new System.Windows.Forms.TextBox();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.lbl_clave = new System.Windows.Forms.Label();
            this.txt_clave = new System.Windows.Forms.TextBox();
            this.lbl_correo = new System.Windows.Forms.Label();
            this.txt_correo = new System.Windows.Forms.TextBox();
            this.btn_insertar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.cmb_rol = new System.Windows.Forms.ComboBox();
            this.lbl_rol = new System.Windows.Forms.Label();
            this.btn_limpiarCampos = new System.Windows.Forms.Button();
            this.txt_conectado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_table)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_table
            // 
            this.gv_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_table.Location = new System.Drawing.Point(12, 12);
            this.gv_table.Name = "gv_table";
            this.gv_table.Size = new System.Drawing.Size(869, 149);
            this.gv_table.TabIndex = 0;
            this.gv_table.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_table_RowHeaderMouseClick);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(979, 18);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 1;
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(979, 56);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(100, 20);
            this.txt_apellido.TabIndex = 2;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(909, 25);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 3;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(909, 63);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_apellido.TabIndex = 4;
            this.lbl_apellido.Text = "Apellido";
            this.lbl_apellido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_estado
            // 
            this.lbl_estado.AutoSize = true;
            this.lbl_estado.Location = new System.Drawing.Point(909, 203);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(40, 13);
            this.lbl_estado.TabIndex = 8;
            this.lbl_estado.Text = "Estado";
            this.lbl_estado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(909, 165);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(43, 13);
            this.lbl_usuario.TabIndex = 7;
            this.lbl_usuario.Text = "Usuario";
            // 
            // txt_estado
            // 
            this.txt_estado.Location = new System.Drawing.Point(979, 196);
            this.txt_estado.Name = "txt_estado";
            this.txt_estado.Size = new System.Drawing.Size(100, 20);
            this.txt_estado.TabIndex = 6;
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(979, 158);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(100, 20);
            this.txt_usuario.TabIndex = 5;
            // 
            // lbl_clave
            // 
            this.lbl_clave.AutoSize = true;
            this.lbl_clave.Location = new System.Drawing.Point(909, 98);
            this.lbl_clave.Name = "lbl_clave";
            this.lbl_clave.Size = new System.Drawing.Size(34, 13);
            this.lbl_clave.TabIndex = 10;
            this.lbl_clave.Text = "Clave";
            // 
            // txt_clave
            // 
            this.txt_clave.Location = new System.Drawing.Point(979, 91);
            this.txt_clave.Name = "txt_clave";
            this.txt_clave.Size = new System.Drawing.Size(100, 20);
            this.txt_clave.TabIndex = 9;
            this.txt_clave.UseSystemPasswordChar = true;
            // 
            // lbl_correo
            // 
            this.lbl_correo.AutoSize = true;
            this.lbl_correo.Location = new System.Drawing.Point(909, 136);
            this.lbl_correo.Name = "lbl_correo";
            this.lbl_correo.Size = new System.Drawing.Size(38, 13);
            this.lbl_correo.TabIndex = 12;
            this.lbl_correo.Text = "Correo";
            this.lbl_correo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_correo
            // 
            this.txt_correo.Location = new System.Drawing.Point(979, 129);
            this.txt_correo.Name = "txt_correo";
            this.txt_correo.Size = new System.Drawing.Size(100, 20);
            this.txt_correo.TabIndex = 11;
            // 
            // btn_insertar
            // 
            this.btn_insertar.Location = new System.Drawing.Point(207, 231);
            this.btn_insertar.Name = "btn_insertar";
            this.btn_insertar.Size = new System.Drawing.Size(75, 23);
            this.btn_insertar.TabIndex = 14;
            this.btn_insertar.Text = "Insertar";
            this.btn_insertar.UseVisualStyleBackColor = true;
            this.btn_insertar.Click += new System.EventHandler(this.btn_insertar_Click);
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(307, 231);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_modificar.TabIndex = 15;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(56, 231);
            this.txt_id.Name = "txt_id";
            this.txt_id.ReadOnly = true;
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 16;
            this.txt_id.Visible = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(408, 231);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 17;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // cmb_rol
            // 
            this.cmb_rol.FormattingEnabled = true;
            this.cmb_rol.Location = new System.Drawing.Point(979, 233);
            this.cmb_rol.Name = "cmb_rol";
            this.cmb_rol.Size = new System.Drawing.Size(100, 21);
            this.cmb_rol.TabIndex = 18;
            // 
            // lbl_rol
            // 
            this.lbl_rol.AutoSize = true;
            this.lbl_rol.Location = new System.Drawing.Point(926, 241);
            this.lbl_rol.Name = "lbl_rol";
            this.lbl_rol.Size = new System.Drawing.Size(23, 13);
            this.lbl_rol.TabIndex = 19;
            this.lbl_rol.Text = "Rol";
            this.lbl_rol.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_limpiarCampos
            // 
            this.btn_limpiarCampos.Location = new System.Drawing.Point(506, 231);
            this.btn_limpiarCampos.Name = "btn_limpiarCampos";
            this.btn_limpiarCampos.Size = new System.Drawing.Size(102, 23);
            this.btn_limpiarCampos.TabIndex = 20;
            this.btn_limpiarCampos.Text = "Limpiar Campos";
            this.btn_limpiarCampos.UseVisualStyleBackColor = true;
            this.btn_limpiarCampos.Click += new System.EventHandler(this.btn_limpiarCampos_Click);
            // 
            // txt_conectado
            // 
            this.txt_conectado.Location = new System.Drawing.Point(979, 271);
            this.txt_conectado.Name = "txt_conectado";
            this.txt_conectado.Size = new System.Drawing.Size(100, 20);
            this.txt_conectado.TabIndex = 21;
            this.txt_conectado.Visible = false;
            // 
            // Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 324);
            this.Controls.Add(this.txt_conectado);
            this.Controls.Add(this.btn_limpiarCampos);
            this.Controls.Add(this.lbl_rol);
            this.Controls.Add(this.cmb_rol);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_insertar);
            this.Controls.Add(this.lbl_correo);
            this.Controls.Add(this.txt_correo);
            this.Controls.Add(this.lbl_clave);
            this.Controls.Add(this.txt_clave);
            this.Controls.Add(this.lbl_estado);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.txt_estado);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.gv_table);
            this.Name = "Other";
            this.Text = "Other";
            this.Load += new System.EventHandler(this.Other_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_table;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.TextBox txt_estado;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label lbl_clave;
        private System.Windows.Forms.TextBox txt_clave;
        private System.Windows.Forms.Label lbl_correo;
        private System.Windows.Forms.TextBox txt_correo;
        private System.Windows.Forms.Button btn_insertar;
        private System.Windows.Forms.Button btn_modificar;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.ComboBox cmb_rol;
        private System.Windows.Forms.Label lbl_rol;
        private System.Windows.Forms.Button btn_limpiarCampos;
        private System.Windows.Forms.TextBox txt_conectado;
    }
}