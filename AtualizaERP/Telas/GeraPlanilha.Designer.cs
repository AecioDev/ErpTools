namespace AtualizaERP.Telas
{
    partial class GeraPlanilha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeraPlanilha));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_PatchPadrao = new System.Windows.Forms.TextBox();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.lb_Cab = new System.Windows.Forms.Label();
            this.cb_GeraCab = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_GerarPlanilha = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_fechar = new System.Windows.Forms.Button();
            this.pg_Progresso = new System.Windows.Forms.ProgressBar();
            this.lb_progress = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_timer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(36, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Salvar Planilha em:";
            // 
            // tb_PatchPadrao
            // 
            this.tb_PatchPadrao.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tb_PatchPadrao.Location = new System.Drawing.Point(39, 111);
            this.tb_PatchPadrao.Name = "tb_PatchPadrao";
            this.tb_PatchPadrao.Size = new System.Drawing.Size(491, 25);
            this.tb_PatchPadrao.TabIndex = 1;
            // 
            // bt_salvar
            // 
            this.bt_salvar.BackColor = System.Drawing.Color.Transparent;
            this.bt_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_salvar.Image = global::AtualizaERP.Properties.Resources.search_icon;
            this.bt_salvar.Location = new System.Drawing.Point(536, 106);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(35, 35);
            this.bt_salvar.TabIndex = 2;
            this.bt_salvar.UseVisualStyleBackColor = false;
            this.bt_salvar.Click += new System.EventHandler(this.bt_salvar_Click);
            // 
            // lb_Cab
            // 
            this.lb_Cab.AutoSize = true;
            this.lb_Cab.BackColor = System.Drawing.Color.Transparent;
            this.lb_Cab.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold);
            this.lb_Cab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.lb_Cab.Location = new System.Drawing.Point(-1, 9);
            this.lb_Cab.Name = "lb_Cab";
            this.lb_Cab.Size = new System.Drawing.Size(534, 50);
            this.lb_Cab.TabIndex = 3;
            this.lb_Cab.Text = "Consulta de Títulos à Receber";
            // 
            // cb_GeraCab
            // 
            this.cb_GeraCab.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cb_GeraCab.FormattingEnabled = true;
            this.cb_GeraCab.Items.AddRange(new object[] {
            "Sem Cabeçalho",
            "Com Cabeçalho"});
            this.cb_GeraCab.Location = new System.Drawing.Point(39, 172);
            this.cb_GeraCab.Name = "cb_GeraCab";
            this.cb_GeraCab.Size = new System.Drawing.Size(172, 25);
            this.cb_GeraCab.TabIndex = 4;
            this.cb_GeraCab.SelectedIndexChanged += new System.EventHandler(this.cb_GeraCab_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(36, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Modelo";
            // 
            // bt_GerarPlanilha
            // 
            this.bt_GerarPlanilha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.bt_GerarPlanilha.FlatAppearance.BorderSize = 0;
            this.bt_GerarPlanilha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_GerarPlanilha.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bt_GerarPlanilha.ForeColor = System.Drawing.Color.Black;
            this.bt_GerarPlanilha.Location = new System.Drawing.Point(413, 165);
            this.bt_GerarPlanilha.Name = "bt_GerarPlanilha";
            this.bt_GerarPlanilha.Size = new System.Drawing.Size(158, 32);
            this.bt_GerarPlanilha.TabIndex = 5;
            this.bt_GerarPlanilha.Text = "Gerar Planilha";
            this.bt_GerarPlanilha.UseVisualStyleBackColor = false;
            this.bt_GerarPlanilha.Click += new System.EventHandler(this.bt_GerarPlanilha_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.panel1.Location = new System.Drawing.Point(8, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 12);
            this.panel1.TabIndex = 6;
            // 
            // bt_fechar
            // 
            this.bt_fechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bt_fechar.FlatAppearance.BorderSize = 0;
            this.bt_fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_fechar.Image = global::AtualizaERP.Properties.Resources.Close_icon;
            this.bt_fechar.Location = new System.Drawing.Point(565, 12);
            this.bt_fechar.Name = "bt_fechar";
            this.bt_fechar.Size = new System.Drawing.Size(23, 23);
            this.bt_fechar.TabIndex = 7;
            this.bt_fechar.UseVisualStyleBackColor = false;
            this.bt_fechar.Click += new System.EventHandler(this.bt_fechar_Click);
            // 
            // pg_Progresso
            // 
            this.pg_Progresso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.pg_Progresso.ForeColor = System.Drawing.Color.Black;
            this.pg_Progresso.Location = new System.Drawing.Point(50, 214);
            this.pg_Progresso.Name = "pg_Progresso";
            this.pg_Progresso.Size = new System.Drawing.Size(501, 23);
            this.pg_Progresso.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pg_Progresso.TabIndex = 8;
            this.pg_Progresso.Value = 99;
            this.pg_Progresso.Visible = false;
            // 
            // lb_progress
            // 
            this.lb_progress.AutoSize = true;
            this.lb_progress.BackColor = System.Drawing.Color.Transparent;
            this.lb_progress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(200)))), ((int)(((byte)(119)))));
            this.lb_progress.Location = new System.Drawing.Point(47, 240);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(43, 17);
            this.lb_progress.TabIndex = 9;
            this.lb_progress.Text = "label3";
            this.lb_progress.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_timer
            // 
            this.lb_timer.AutoSize = true;
            this.lb_timer.BackColor = System.Drawing.Color.Transparent;
            this.lb_timer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lb_timer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lb_timer.Location = new System.Drawing.Point(12, 274);
            this.lb_timer.Name = "lb_timer";
            this.lb_timer.Size = new System.Drawing.Size(104, 17);
            this.lb_timer.TabIndex = 10;
            this.lb_timer.Text = "Fechando em: 5";
            this.lb_timer.Visible = false;
            // 
            // GeraPlanilha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.lb_timer);
            this.Controls.Add(this.lb_progress);
            this.Controls.Add(this.pg_Progresso);
            this.Controls.Add(this.bt_fechar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bt_GerarPlanilha);
            this.Controls.Add(this.cb_GeraCab);
            this.Controls.Add(this.lb_Cab);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.tb_PatchPadrao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GeraPlanilha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Planilha";
            this.Load += new System.EventHandler(this.GeraPlanilha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_PatchPadrao;
        private System.Windows.Forms.Button bt_salvar;
        private System.Windows.Forms.Label lb_Cab;
        private System.Windows.Forms.ComboBox cb_GeraCab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_GerarPlanilha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_fechar;
        public System.Windows.Forms.ProgressBar pg_Progresso;
        public System.Windows.Forms.Label lb_progress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_timer;
    }
}