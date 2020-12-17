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
    public partial class InfoUpdate : Form
    {
        //Acessa ao Banco e Verifica se tem conexões aberta no Banco.
        AcessoDados dados = new AcessoDados();

        private int Tipo = 0;
        private string SenhaBD = "";
        private string IdConex = "";

        public InfoUpdate(int _tipo, string _idconex)
        {
            Tipo = _tipo;
            //SenhaBD = _senha;
            IdConex = _idconex;
            InitializeComponent();
        }

        private void bt_Atualizar_Click(object sender, EventArgs e) //Atualizar Agora.
        {
            if (Tipo == 0) //Atualização Completa - Download dos Executáveis - Backup do Banco de Dados - Atualização do Banco de Dados
            {                

                var acessos = dados.ConsAcessos(IdConex);

                if (acessos.Count() > 0)
                {
                    //Chama form para mostrar as conexões em aberto
                    this.Hide();
                    ListaConexoes verCon = new ListaConexoes(IdConex);
                    verCon.ShowDialog();
                    this.Show();
                }

                acessos = dados.ConsAcessos(IdConex);

                if (acessos.Count() > 0)
                {
                    MessageBox.Show("Favor Finalizar Todas as Conexões do Controller ERP com o Banco de Dados antes de continuar a Atualização.", "Controller ERP");
                    this.Close();
                }
            }

            if (Tipo == 1) //Atualização de Executáveis na Estação - Faz o Download e Instala.
            {

            }
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
