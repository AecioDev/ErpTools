using AtualizaERP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtualizaERP.Telas
{
    public partial class ExibeAlerta : Form
    {
        private int TempoRestante = 0;
        private int TempoFechar = 0;
        private string MsgP1;
        private string MsgP2;
        private string Usuario;
        private string IdConex;
        private int Tipo;
        private DateTime DataTarefa;

        public ExibeAlerta(int _tempRest, string _msg1, string _msg2, string _user, string _idCon, DateTime _dataIni, int _tipo)
        {
            TempoRestante = _tempRest;
            MsgP1 = _msg1;
            MsgP2 = _msg2;
            Usuario = _user;
            IdConex = _idCon;
            DataTarefa = _dataIni;
            Tipo = _tipo;

            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5, Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);
        }


        private void CriarTarefa_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Tipo: " + Tipo.ToString());
            if (Tipo == 0) //Exibe Alertas com Contador de tempo
            {
                bt_msgP1.Text = "Olá! Passando aqui pra avisar que " + MsgP1.Trim();

                if (TempoRestante != 30)
                {
                    TempoFechar = 10; //Segundos
                    bt_msgMeio.Text = TempoRestante + " MINUTOS!";
                }
                else
                {
                    TempoFechar = 30; //Segundos
                    bt_msgMeio.Text = TempoRestante + " SEGUNDOS!";
                }

                bt_msgP2.Text = MsgP2.Trim();

                timer1.Enabled = true;
            }

            if(Tipo == 1) //Exibe Alerta Fixo para o Usuário Fechar.
            {
                bt_msgP1.Text = "";
                bt_msgMeio.Text = MsgP1.Trim();
                bt_msgP2.Text = MsgP2.Trim();
                timer1.Enabled = false;
            }
        }
        
        private void bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TempoRestante == 30)
            {
                bt_msgMeio.Text = TempoFechar + " SEGUNDOS!";
            }

            if (TempoFechar <= 0)
            {
                if (TempoRestante != 30)
                    this.Close();
                else
                {
                    //Cria uma Tarefa para Verificar a conexão a cada 1 minuto
                    CriaTarefa newTarefa = new CriaTarefa(Usuario, DataTarefa, 1, IdConex);
                    newTarefa.AgendaVerCon();

                    bt_msgP1.Text = "";
                    bt_msgMeio.Text = "TEMPO ACABADO!!!";
                    bt_msgP2.Text = "Você será avisado quando o sistema estiver online novamente!";
                }
            }
            else
                TempoFechar--;
        }
    }
}
