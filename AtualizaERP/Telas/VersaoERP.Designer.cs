namespace AtualizaERP.Telas
{
    partial class VersaoERP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersaoERP));
            this.bt_Fechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Cab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt_Fechar
            // 
            this.bt_Fechar.BackColor = System.Drawing.Color.Transparent;
            this.bt_Fechar.FlatAppearance.BorderSize = 0;
            this.bt_Fechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Fechar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Fechar.Image = global::AtualizaERP.Properties.Resources.Closee;
            this.bt_Fechar.Location = new System.Drawing.Point(429, 5);
            this.bt_Fechar.Name = "bt_Fechar";
            this.bt_Fechar.Size = new System.Drawing.Size(39, 37);
            this.bt_Fechar.TabIndex = 12;
            this.bt_Fechar.UseVisualStyleBackColor = false;
            this.bt_Fechar.Click += new System.EventHandler(this.bt_Fechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(25, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Controle de Versões";
            // 
            // lb_Cab
            // 
            this.lb_Cab.AutoSize = true;
            this.lb_Cab.BackColor = System.Drawing.Color.Transparent;
            this.lb_Cab.Font = new System.Drawing.Font("Nirmala UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Cab.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lb_Cab.Location = new System.Drawing.Point(-3, 89);
            this.lb_Cab.Name = "lb_Cab";
            this.lb_Cab.Size = new System.Drawing.Size(242, 37);
            this.lb_Cab.TabIndex = 10;
            this.lb_Cab.Text = "Atualizando Dados";
            // 
            // VersaoERP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AtualizaERP.Properties.Resources.Fundo_3;
            this.ClientSize = new System.Drawing.Size(473, 286);
            this.Controls.Add(this.bt_Fechar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_Cab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VersaoERP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VersaoERP";
            this.Load += new System.EventHandler(this.VersaoERP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Fechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_Cab;

    }
}