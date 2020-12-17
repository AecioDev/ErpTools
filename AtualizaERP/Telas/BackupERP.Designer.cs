namespace AtualizaERP.Telas
{
    partial class BackupERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupERP));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lb_Cab = new System.Windows.Forms.Label();
            this.lb_Info = new System.Windows.Forms.Label();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.bt_Fechar = new System.Windows.Forms.Button();
            this.lb_Encerrar = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_carregando = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(29, 112);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(571, 47);
            this.progressBar.TabIndex = 5;
            // 
            // lb_Cab
            // 
            this.lb_Cab.AutoSize = true;
            this.lb_Cab.BackColor = System.Drawing.Color.Transparent;
            this.lb_Cab.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Cab.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_Cab.Location = new System.Drawing.Point(6, 6);
            this.lb_Cab.Name = "lb_Cab";
            this.lb_Cab.Size = new System.Drawing.Size(0, 37);
            this.lb_Cab.TabIndex = 4;
            // 
            // lb_Info
            // 
            this.lb_Info.AutoSize = true;
            this.lb_Info.BackColor = System.Drawing.Color.Transparent;
            this.lb_Info.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.lb_Info.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_Info.Location = new System.Drawing.Point(38, 167);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(202, 28);
            this.lb_Info.TabIndex = 8;
            this.lb_Info.Text = "Download Finalizado!";
            this.lb_Info.Visible = false;
            // 
            // lb_Progress
            // 
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.BackColor = System.Drawing.Color.Transparent;
            this.lb_Progress.Font = new System.Drawing.Font("Nirmala UI", 20.25F);
            this.lb_Progress.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_Progress.Location = new System.Drawing.Point(26, 72);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(54, 37);
            this.lb_Progress.TabIndex = 9;
            this.lb_Progress.Text = "0%";
            // 
            // bt_Fechar
            // 
            this.bt_Fechar.BackColor = System.Drawing.Color.Transparent;
            this.bt_Fechar.FlatAppearance.BorderSize = 0;
            this.bt_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Fechar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Fechar.Image = global::AtualizaERP.Properties.Resources.Closee;
            this.bt_Fechar.Location = new System.Drawing.Point(586, 5);
            this.bt_Fechar.Name = "bt_Fechar";
            this.bt_Fechar.Size = new System.Drawing.Size(39, 37);
            this.bt_Fechar.TabIndex = 7;
            this.bt_Fechar.UseVisualStyleBackColor = false;
            this.bt_Fechar.Visible = false;
            this.bt_Fechar.Click += new System.EventHandler(this.bt_Fechar_Click);
            // 
            // lb_Encerrar
            // 
            this.lb_Encerrar.AutoSize = true;
            this.lb_Encerrar.BackColor = System.Drawing.Color.Transparent;
            this.lb_Encerrar.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Encerrar.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_Encerrar.Location = new System.Drawing.Point(6, 256);
            this.lb_Encerrar.Name = "lb_Encerrar";
            this.lb_Encerrar.Size = new System.Drawing.Size(0, 37);
            this.lb_Encerrar.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_carregando
            // 
            this.lb_carregando.AutoSize = true;
            this.lb_carregando.BackColor = System.Drawing.Color.Transparent;
            this.lb_carregando.ForeColor = System.Drawing.SystemColors.Control;
            this.lb_carregando.Location = new System.Drawing.Point(302, 283);
            this.lb_carregando.Name = "lb_carregando";
            this.lb_carregando.Size = new System.Drawing.Size(0, 13);
            this.lb_carregando.TabIndex = 10;
            // 
            // BackupERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.Fundo_Download2;
            this.ClientSize = new System.Drawing.Size(631, 302);
            this.Controls.Add(this.lb_carregando);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lb_Encerrar);
            this.Controls.Add(this.lb_Cab);
            this.Controls.Add(this.lb_Info);
            this.Controls.Add(this.lb_Progress);
            this.Controls.Add(this.bt_Fechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupERP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.BackupERP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lb_Cab;
        private System.Windows.Forms.Label lb_Info;
        private System.Windows.Forms.Label lb_Progress;
        private System.Windows.Forms.Button bt_Fechar;
        private System.Windows.Forms.Label lb_Encerrar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_carregando;
    }
}