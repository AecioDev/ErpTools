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
            this.SuspendLayout();
            // 
            // bt_Atualizar
            // 
            this.bt_Atualizar.FlatAppearance.BorderSize = 0;
            this.bt_Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Atualizar.Image = global::AtualizaERP.Properties.Resources.atualizacaobotaoatualizar;
            this.bt_Atualizar.Location = new System.Drawing.Point(256, 245);
            this.bt_Atualizar.Name = "bt_Atualizar";
            this.bt_Atualizar.Size = new System.Drawing.Size(124, 45);
            this.bt_Atualizar.TabIndex = 0;
            this.bt_Atualizar.UseVisualStyleBackColor = true;
            this.bt_Atualizar.Click += new System.EventHandler(this.bt_Atualizar_Click);
            // 
            // bt_Baixar
            // 
            this.bt_Baixar.FlatAppearance.BorderSize = 0;
            this.bt_Baixar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Baixar.Image = global::AtualizaERP.Properties.Resources.atualizacaobotaobaixar;
            this.bt_Baixar.Location = new System.Drawing.Point(57, 245);
            this.bt_Baixar.Name = "bt_Baixar";
            this.bt_Baixar.Size = new System.Drawing.Size(124, 45);
            this.bt_Baixar.TabIndex = 0;
            this.bt_Baixar.UseVisualStyleBackColor = true;
            // 
            // bt_Lembrar
            // 
            this.bt_Lembrar.FlatAppearance.BorderSize = 0;
            this.bt_Lembrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Lembrar.Image = global::AtualizaERP.Properties.Resources.atualizacaobotaolembrar;
            this.bt_Lembrar.Location = new System.Drawing.Point(455, 245);
            this.bt_Lembrar.Name = "bt_Lembrar";
            this.bt_Lembrar.Size = new System.Drawing.Size(124, 45);
            this.bt_Lembrar.TabIndex = 0;
            this.bt_Lembrar.UseVisualStyleBackColor = true;
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
            // InfoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(61)))));
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.atualizacaotelafundoatualizacao;
            this.ClientSize = new System.Drawing.Size(637, 322);
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
    }
}