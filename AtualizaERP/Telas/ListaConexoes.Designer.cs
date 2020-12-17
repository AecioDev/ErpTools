namespace AtualizaERP.Telas
{
    partial class ListaConexoes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaConexoes));
            this.bt_Fechar = new System.Windows.Forms.Button();
            this.grid_Dados = new System.Windows.Forms.DataGridView();
            this.nomeBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maqAcesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_Atualizar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.acessoDadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Dados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acessoDadosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Fechar
            // 
            this.bt_Fechar.FlatAppearance.BorderSize = 0;
            this.bt_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Fechar.Image = global::AtualizaERP.Properties.Resources.atualizacaoxfechar;
            this.bt_Fechar.Location = new System.Drawing.Point(567, 8);
            this.bt_Fechar.Name = "bt_Fechar";
            this.bt_Fechar.Size = new System.Drawing.Size(23, 23);
            this.bt_Fechar.TabIndex = 2;
            this.bt_Fechar.UseVisualStyleBackColor = true;
            this.bt_Fechar.Click += new System.EventHandler(this.bt_Fechar_Click);
            // 
            // grid_Dados
            // 
            this.grid_Dados.AllowUserToAddRows = false;
            this.grid_Dados.AllowUserToDeleteRows = false;
            this.grid_Dados.AutoGenerateColumns = false;
            this.grid_Dados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Dados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grid_Dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Dados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeBD,
            this.maqAcesso});
            this.grid_Dados.DataSource = this.acessoDadosBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_Dados.DefaultCellStyle = dataGridViewCellStyle2;
            this.grid_Dados.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.grid_Dados.Location = new System.Drawing.Point(87, 80);
            this.grid_Dados.Name = "grid_Dados";
            this.grid_Dados.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_Dados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grid_Dados.RowHeadersVisible = false;
            this.grid_Dados.Size = new System.Drawing.Size(424, 150);
            this.grid_Dados.TabIndex = 3;
            // 
            // nomeBD
            // 
            this.nomeBD.DataPropertyName = "DbName";
            this.nomeBD.HeaderText = "Banco de Dados";
            this.nomeBD.Name = "nomeBD";
            this.nomeBD.ReadOnly = true;
            this.nomeBD.Width = 200;
            // 
            // maqAcesso
            // 
            this.maqAcesso.DataPropertyName = "HostName";
            this.maqAcesso.HeaderText = "Host Logado";
            this.maqAcesso.Name = "maqAcesso";
            this.maqAcesso.ReadOnly = true;
            this.maqAcesso.Width = 200;
            // 
            // bt_Atualizar
            // 
            this.bt_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Atualizar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Atualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Atualizar.Location = new System.Drawing.Point(432, 239);
            this.bt_Atualizar.Name = "bt_Atualizar";
            this.bt_Atualizar.Size = new System.Drawing.Size(107, 32);
            this.bt_Atualizar.TabIndex = 4;
            this.bt_Atualizar.Text = "Atualizar 05";
            this.bt_Atualizar.UseVisualStyleBackColor = true;
            this.bt_Atualizar.Click += new System.EventHandler(this.bt_Atualizar_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(53, 15);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(492, 59);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Algumas Estações de Trabalho ainda estão conectadas ao Banco de Dados do Controll" +
    "er ERP";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(59, 242);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(367, 26);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Favor Desconectar as Estações Acima!";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // acessoDadosBindingSource
            // 
            this.acessoDadosBindingSource.DataSource = typeof(AtualizaERP.Classes.AcessoDados);
            // 
            // ListaConexoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(599, 289);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_Atualizar);
            this.Controls.Add(this.grid_Dados);
            this.Controls.Add(this.bt_Fechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListaConexoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListaConexoes";
            this.Load += new System.EventHandler(this.ListaConexoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Dados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acessoDadosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Fechar;
        private System.Windows.Forms.DataGridView grid_Dados;
        private System.Windows.Forms.BindingSource acessoDadosBindingSource;
        private System.Windows.Forms.Button bt_Atualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn maqAcesso;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
    }
}