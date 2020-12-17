namespace AtualizaERP.Telas
{
    partial class DownloadERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadERP));
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.bt_Fechar = new System.Windows.Forms.Button();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.lb_Info = new System.Windows.Forms.Label();
            this.bt_Abrir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Efetuando o Download...";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 119);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(571, 47);
            this.progressBar.TabIndex = 1;
            // 
            // bt_Fechar
            // 
            this.bt_Fechar.BackColor = System.Drawing.Color.Transparent;
            this.bt_Fechar.FlatAppearance.BorderSize = 0;
            this.bt_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Fechar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Fechar.Image = global::AtualizaERP.Properties.Resources.Close_Folder_48x48;
            this.bt_Fechar.Location = new System.Drawing.Point(518, 158);
            this.bt_Fechar.Name = "bt_Fechar";
            this.bt_Fechar.Size = new System.Drawing.Size(51, 50);
            this.bt_Fechar.TabIndex = 2;
            this.bt_Fechar.UseVisualStyleBackColor = false;
            this.bt_Fechar.Visible = false;
            this.bt_Fechar.Click += new System.EventHandler(this.bt_Fechar_Click);
            // 
            // lb_Progress
            // 
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.BackColor = System.Drawing.Color.Transparent;
            this.lb_Progress.Font = new System.Drawing.Font("Nirmala UI", 20.25F);
            this.lb_Progress.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_Progress.Location = new System.Drawing.Point(26, 79);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(54, 37);
            this.lb_Progress.TabIndex = 3;
            this.lb_Progress.Text = "0%";
            // 
            // lb_Info
            // 
            this.lb_Info.AutoSize = true;
            this.lb_Info.BackColor = System.Drawing.Color.Transparent;
            this.lb_Info.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.lb_Info.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_Info.Location = new System.Drawing.Point(52, 172);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(407, 28);
            this.lb_Info.TabIndex = 3;
            this.lb_Info.Text = "Download Finalizado! Deseja executar agora?";
            this.lb_Info.Visible = false;
            // 
            // bt_Abrir
            // 
            this.bt_Abrir.BackColor = System.Drawing.Color.Transparent;
            this.bt_Abrir.FlatAppearance.BorderSize = 0;
            this.bt_Abrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Abrir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Abrir.Image = global::AtualizaERP.Properties.Resources.Open_Folder_48x48;
            this.bt_Abrir.Location = new System.Drawing.Point(458, 158);
            this.bt_Abrir.Name = "bt_Abrir";
            this.bt_Abrir.Size = new System.Drawing.Size(51, 50);
            this.bt_Abrir.TabIndex = 2;
            this.bt_Abrir.UseVisualStyleBackColor = false;
            this.bt_Abrir.Visible = false;
            this.bt_Abrir.Click += new System.EventHandler(this.bt_Abrir_Click);
            // 
            // DownloadERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.Fundo_Download2;
            this.ClientSize = new System.Drawing.Size(631, 302);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.bt_Abrir);
            this.Controls.Add(this.bt_Fechar);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadERP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download ERP";
            this.Load += new System.EventHandler(this.DownloadERP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button bt_Fechar;
        private System.Windows.Forms.Label lb_Progress;
        private System.Windows.Forms.Label lb_Info;
        private System.Windows.Forms.Button bt_Abrir;
    }
}