namespace AtualizaERP.Telas
{
    partial class InfoUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoUpdate));
            this.bt_Atualizar = new System.Windows.Forms.Button();
            this.bt_Baixar = new System.Windows.Forms.Button();
            this.bt_Lembrar = new System.Windows.Forms.Button();
            this.bt_Fechar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // bt_Atualizar
            // 
            this.bt_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Atualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Atualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Atualizar.Location = new System.Drawing.Point(256, 245);
            this.bt_Atualizar.Name = "bt_Atualizar";
            this.bt_Atualizar.Size = new System.Drawing.Size(124, 45);
            this.bt_Atualizar.TabIndex = 0;
            this.bt_Atualizar.Text = "ATUALIZAR AGORA";
            this.bt_Atualizar.UseVisualStyleBackColor = true;
            this.bt_Atualizar.Click += new System.EventHandler(this.bt_Atualizar_Click);
            // 
            // bt_Baixar
            // 
            this.bt_Baixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Baixar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_Baixar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Baixar.Location = new System.Drawing.Point(57, 245);
            this.bt_Baixar.Name = "bt_Baixar";
            this.bt_Baixar.Size = new System.Drawing.Size(124, 45);
            this.bt_Baixar.TabIndex = 0;
            this.bt_Baixar.Text = "AGENDAR ATUALIZAÇÃO";
            this.bt_Baixar.UseVisualStyleBackColor = true;
            // 
            // bt_Lembrar
            // 
            this.bt_Lembrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Lembrar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_Lembrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bt_Lembrar.Location = new System.Drawing.Point(455, 245);
            this.bt_Lembrar.Name = "bt_Lembrar";
            this.bt_Lembrar.Size = new System.Drawing.Size(124, 45);
            this.bt_Lembrar.TabIndex = 0;
            this.bt_Lembrar.Text = "LEMBRAR MAIS TARDE";
            this.bt_Lembrar.UseVisualStyleBackColor = true;
            this.bt_Lembrar.Click += new System.EventHandler(this.bt_Lembrar_Click);
            // 
            // bt_Fechar
            // 
            this.bt_Fechar.FlatAppearance.BorderSize = 0;
            this.bt_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Fechar.Image = global::AtualizaERP.Properties.Resources.atualizacaoxfechar;
            this.bt_Fechar.Location = new System.Drawing.Point(607, 6);
            this.bt_Fechar.Name = "bt_Fechar";
            this.bt_Fechar.Size = new System.Drawing.Size(23, 23);
            this.bt_Fechar.TabIndex = 1;
            this.bt_Fechar.UseVisualStyleBackColor = true;
            this.bt_Fechar.Click += new System.EventHandler(this.bt_Fechar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(110, 176);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(415, 23);
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            // 
            // InfoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.atualizacaotelafundoatualizacao;
            this.ClientSize = new System.Drawing.Size(637, 322);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bt_Fechar);
            this.Controls.Add(this.bt_Lembrar);
            this.Controls.Add(this.bt_Atualizar);
            this.Controls.Add(this.bt_Baixar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InfoUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoUpdate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_Atualizar;
        private System.Windows.Forms.Button bt_Baixar;
        private System.Windows.Forms.Button bt_Lembrar;
        private System.Windows.Forms.Button bt_Fechar;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}