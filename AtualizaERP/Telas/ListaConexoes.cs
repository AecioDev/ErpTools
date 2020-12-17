using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AtualizaERP.Classes;

namespace AtualizaERP.Telas
{
    public partial class ListaConexoes : Form
    {
        private int segundo = 5;

        private string Banco = "";
        private bool continuar = false;

        public ListaConexoes(string _banco)
        {
            Banco = _banco;
            InitializeComponent();
        }

        private void ListaConexoes_Load(object sender, EventArgs e)
        {
            ListaAcessos();
            timer1.Enabled = true;
        }

        private void ListaAcessos()
        {
            List<AcessosModel> Acessos = new List<AcessosModel>();
            AcessoDados dados = new AcessoDados();

            Acessos = dados.ConsAcessos(Banco);

            //acessoDadosBindingSource.DataSource = Acessos;
            grid_Dados.DataSource = Acessos;
            grid_Dados.Refresh();

            if (Acessos.Count == 0)
            {
                bt_Atualizar.Text = "Continuar";
                continuar = true;
                timer1.Enabled = false;
            }
        }

        private void bt_Atualizar_Click(object sender, EventArgs e)
        {
            if (continuar)
                this.Close();
            else
                ListaAcessos();
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string seg = "0" + segundo;

            bt_Atualizar.Text = "Atualizar " + seg;
            segundo--;
            
            if (segundo <= 0)
            {
                ListaAcessos();
                segundo = 5;
            }
        }
        
    }
}


/*
//Globais
private int tempoFim = 120; //2 min
private int minuto = 0;
private int segundo = 0;


private void ListaConexoes_Load(object sender, EventArgs e)
        {
            string min = "";
            string seg = "";

            acessoDadosBindingSource.DataSource = Acessos;
            grid_Dados.Refresh();

            if (tempoFim >= 60)
            {
                minuto = tempoFim / 60;
                segundo = tempoFim % 60;
            }
            else
            {
                minuto = 0;
                segundo = tempoFim;
            }

            if (minuto < 10)
                min = "0" + minuto;
            else
                min = minuto.ToString();

            if (segundo < 10)
                seg = "0" + segundo;
            else
                seg = segundo.ToString();

            lb_Info.Text = "Encerramento Automático em: " + min + ":" + seg;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string min = "";
            string seg = "";

            segundo--;
            if (minuto > 0 && segundo < 0)
            {
                minuto--;
                segundo = 59;
            }

            if (minuto < 10)
                min = "0" + minuto;
            else
                min = minuto.ToString();

            if (segundo < 10)
                seg = "0" + segundo;
            else
                seg = segundo.ToString();

            lb_Info.Text = "Encerramento Automático em: " + min + ":" + seg;

            if (minuto == 0 && segundo == 0)
            {
                timer1.Enabled = false;
                FechaConexoes();
            }
        }
*/