namespace AtualizaERP.Telas
{
    partial class ExibeAlerta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExibeAlerta));
            this.bt_fechar = new System.Windows.Forms.Button();
            this.bt_msgP1 = new System.Windows.Forms.Button();
            this.bt_msgP2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bt_msgMeio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_fechar
            // 
            this.bt_fechar.BackColor = System.Drawing.Color.Transparent;
            this.bt_fechar.FlatAppearance.BorderSize = 0;
            this.bt_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fechar.Image = global::AtualizaERP.Properties.Resources.sair_bt;
            this.bt_fechar.Location = new System.Drawing.Point(565, 12);
            this.bt_fechar.Name = "bt_fechar";
            this.bt_fechar.Size = new System.Drawing.Size(23, 23);
            this.bt_fechar.TabIndex = 5;
            this.bt_fechar.UseVisualStyleBackColor = false;
            this.bt_fechar.Click += new System.EventHandler(this.bt_fechar_Click);
            // 
            // bt_msgP1
            // 
            this.bt_msgP1.BackColor = System.Drawing.Color.Transparent;
            this.bt_msgP1.FlatAppearance.BorderSize = 0;
            this.bt_msgP1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_msgP1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_msgP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_msgP1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_msgP1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_msgP1.Location = new System.Drawing.Point(9, 71);
            this.bt_msgP1.Name = "bt_msgP1";
            this.bt_msgP1.Size = new System.Drawing.Size(579, 59);
            this.bt_msgP1.TabIndex = 6;
            this.bt_msgP1.Text = "Para fins de MANUTENCAO no BANCO DE DADOS todas atividades do Controller ERP serã" +
    "o encerradas em:";
            this.bt_msgP1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_msgP1.UseVisualStyleBackColor = false;
            // 
            // bt_msgP2
            // 
            this.bt_msgP2.BackColor = System.Drawing.Color.Transparent;
            this.bt_msgP2.FlatAppearance.BorderSize = 0;
            this.bt_msgP2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_msgP2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_msgP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_msgP2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_msgP2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_msgP2.Location = new System.Drawing.Point(9, 182);
            this.bt_msgP2.Name = "bt_msgP2";
            this.bt_msgP2.Size = new System.Drawing.Size(579, 83);
            this.bt_msgP2.TabIndex = 7;
            this.bt_msgP2.Text = "Essa operação é OBRIGATÓRIA e NÃO pode ser interrompida! Feche seus trabalhos e a" +
    "guarde o fim da manutenção do banco de dados.";
            this.bt_msgP2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bt_msgP2.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bt_msgMeio
            // 
            this.bt_msgMeio.BackColor = System.Drawing.Color.Transparent;
            this.bt_msgMeio.FlatAppearance.BorderSize = 0;
            this.bt_msgMeio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.bt_msgMeio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.bt_msgMeio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_msgMeio.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_msgMeio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.bt_msgMeio.Location = new System.Drawing.Point(9, 131);
            this.bt_msgMeio.Name = "bt_msgMeio";
            this.bt_msgMeio.Size = new System.Drawing.Size(579, 50);
            this.bt_msgMeio.TabIndex = 6;
            this.bt_msgMeio.Text = "15 MINUTOS";
            this.bt_msgMeio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bt_msgMeio.UseVisualStyleBackColor = false;
            // 
            // ExibeAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.bt_msgP2);
            this.Controls.Add(this.bt_msgMeio);
            this.Controls.Add(this.bt_msgP1);
            this.Controls.Add(this.bt_fechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExibeAlerta";
            this.Opacity = 0.75D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CriarTarefa";
            this.Load += new System.EventHandler(this.CriarTarefa_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_fechar;
        private System.Windows.Forms.Button bt_msgP1;
        private System.Windows.Forms.Button bt_msgP2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button bt_msgMeio;
    }
}