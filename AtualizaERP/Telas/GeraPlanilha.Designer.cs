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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeraPlanilha));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_PatchPadrao = new System.Windows.Forms.TextBox();
            this.bt_salvar = new System.Windows.Forms.Button();
            this.lb_Cab = new System.Windows.Forms.Label();
            this.cb_GeraCab = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_GerarPlanilha = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pasta do Relatório";
            // 
            // tb_PatchPadrao
            // 
            this.tb_PatchPadrao.Location = new System.Drawing.Point(21, 89);
            this.tb_PatchPadrao.Name = "tb_PatchPadrao";
            this.tb_PatchPadrao.Size = new System.Drawing.Size(368, 20);
            this.tb_PatchPadrao.TabIndex = 1;
            // 
            // bt_salvar
            // 
            this.bt_salvar.Location = new System.Drawing.Point(395, 88);
            this.bt_salvar.Name = "bt_salvar";
            this.bt_salvar.Size = new System.Drawing.Size(75, 23);
            this.bt_salvar.TabIndex = 2;
            this.bt_salvar.Text = "Alterar";
            this.bt_salvar.UseVisualStyleBackColor = true;
            this.bt_salvar.Click += new System.EventHandler(this.bt_salvar_Click);
            // 
            // lb_Cab
            // 
            this.lb_Cab.AutoSize = true;
            this.lb_Cab.Location = new System.Drawing.Point(12, 9);
            this.lb_Cab.Name = "lb_Cab";
            this.lb_Cab.Size = new System.Drawing.Size(35, 13);
            this.lb_Cab.TabIndex = 3;
            this.lb_Cab.Text = "label2";
            // 
            // cb_GeraCab
            // 
            this.cb_GeraCab.FormattingEnabled = true;
            this.cb_GeraCab.Items.AddRange(new object[] {
            "Sem Cabeçalho",
            "Com Cabeçalho"});
            this.cb_GeraCab.Location = new System.Drawing.Point(21, 136);
            this.cb_GeraCab.Name = "cb_GeraCab";
            this.cb_GeraCab.Size = new System.Drawing.Size(140, 21);
            this.cb_GeraCab.TabIndex = 4;
            this.cb_GeraCab.SelectedIndexChanged += new System.EventHandler(this.cb_GeraCab_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Modelo";
            // 
            // bt_GerarPlanilha
            // 
            this.bt_GerarPlanilha.Location = new System.Drawing.Point(218, 136);
            this.bt_GerarPlanilha.Name = "bt_GerarPlanilha";
            this.bt_GerarPlanilha.Size = new System.Drawing.Size(252, 23);
            this.bt_GerarPlanilha.TabIndex = 5;
            this.bt_GerarPlanilha.Text = "Gerar Planilha";
            this.bt_GerarPlanilha.UseVisualStyleBackColor = true;
            this.bt_GerarPlanilha.Click += new System.EventHandler(this.bt_GerarPlanilha_Click);
            // 
            // GeraPlanilha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 195);
            this.Controls.Add(this.bt_GerarPlanilha);
            this.Controls.Add(this.cb_GeraCab);
            this.Controls.Add(this.lb_Cab);
            this.Controls.Add(this.bt_salvar);
            this.Controls.Add(this.tb_PatchPadrao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}