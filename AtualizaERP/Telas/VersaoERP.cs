using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AtualizaERP.Classes;

namespace AtualizaERP.Telas
{
    public partial class VersaoERP : Form
    {
        private int IdVersao = 0;
        private int CodVersao = 0;
        private int Opcao = 0;
        private string DescVersao = "";
        private string DataVersao;
        private string ImpactDB = "";
        private string URLVersao = "";
        private string URLRelease = "";


        public VersaoERP(string _idVersao, string _codVersao, string _descVersao, string _dataVersao, string _impactbd, string _urlversao, string _urlrelease, string caso)
        {            
            if (!string.IsNullOrEmpty(_idVersao))
                IdVersao = Convert.ToInt32(_idVersao);

            if (!string.IsNullOrEmpty(_codVersao))
                CodVersao = Convert.ToInt32(_codVersao);

            DescVersao = _descVersao;
            DataVersao = _dataVersao;
            ImpactDB = _impactbd;
            URLVersao = _urlversao;
            URLRelease = _urlrelease;

            if (!string.IsNullOrEmpty(caso))
                Opcao = Convert.ToInt32(caso);

            InitializeComponent();
        }

        private void VersaoERP_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("ID: " + IdVersao + "Cod: "+ CodVersao + "Sta: "+ StaVersao + "Desc: "+ DescVersao + "Data: "+ DataVersao + "Caso: " + Opcao);
            if (Opcao == 0) //Cadastro inicial das Versões
                CadastroInicial();
            else
                CadastraVersao();

            Tchau();
        }

        private void Tchau() { this.Close(); }

        private void CadastraVersao()
        {
            string result = "";
            AcessoDados dados = new AcessoDados();
            VersaoModel Versao = new VersaoModel(IdVersao, CodVersao, DescVersao, DataVersao, ImpactDB, URLVersao, URLRelease);

            if (Opcao == 1) //Verifica se a versão informada já existe antes de inserir
            {                
                var versoes = dados.ConsVersao(0, CodVersao);

                if (versoes.Count() > 0)
                {
                    result = "Versões Encontradas\n";
                    foreach (VersaoModel ver in versoes)
                    {
                        result += "Id: " + ver.IdVersao + " - " + ver.CodVersao + " Data: " + ver.DataVersao + "\n";
                    }
                    MessageBox.Show("A Versão informada já Foi Cadastrada!!!\n" + result, "Controle de Versões");
                    return;
                }
            }

            result = dados.CadVersao(Versao, Opcao);

            if (result != "OK")
                MessageBox.Show("Ocorreram Erros ao Cadastrar/Alterar a Versão no Sistema!!!\n\n" + result, "Controle de Versões");
        }

        private void CadastroInicial()
        {
            string result = "";
            AcessoDados dados = new AcessoDados();
            
            var versoes = VersoesIniciais().ToList();

            foreach (VersaoModel versao in versoes)
            {
                result = dados.CadVersao(versao, 1);

                if (result != "OK")
                    MessageBox.Show("Ocorreram Erros ao Cadastrar/Alterar a Versão no Sistema!!!\n\n" + result, "Controle de Versões");
            }
        }

        private List<VersaoModel> VersoesIniciais()
        {
            //Versoes.Add(new VersaoModel(IdVersao, CodVersao, VersaoAtual, DescVersao, DataVersao, ImpactDB, URLVersao, URLRelease))
            List<VersaoModel> Versoes = new List<VersaoModel>();
            Versoes.Add(new VersaoModel(127, 5201901, "5.2019.01.00", "08/03/2019", "S", "http://www.controllernet.com.br/controllernovo/download/Arquivos/VersoesERP/5.2019/Controller520190100_08032019.exe", ""));
            Versoes.Add(new VersaoModel(126, 42705001, "04.27.05.001", "20/02/2019", " ", " ", " "));
            Versoes.Add(new VersaoModel(125, 42705000, "04.27.05.000", "06/02/2019", "", "", ""));
            Versoes.Add(new VersaoModel(124, 42704000, "04.27.04.000", "28/11/2018", "", "", ""));
            Versoes.Add(new VersaoModel(123, 42703000, "04.27.03.000", "23/11/2018", "", "", ""));
            Versoes.Add(new VersaoModel(122, 42703000, "04.27.03.000", "24/10/2018", "", "", ""));
            Versoes.Add(new VersaoModel(121, 42702000, "04.27.02.000", "21/09/2018", "", "", ""));
            Versoes.Add(new VersaoModel(120, 42701000, "04.27.01.000", "09/08/2018", "", "", ""));
            Versoes.Add(new VersaoModel(119, 42700000, "04.27.00.000", "26/07/2018", "", "", ""));
            Versoes.Add(new VersaoModel(118, 42600000, "04.26.00.000", "18/06/2018", "", "", ""));
            Versoes.Add(new VersaoModel(117, 42501000, "04.25.01.000", "10/04/2018", "", "", ""));
            Versoes.Add(new VersaoModel(116, 42500000, "04.25.00.000", "26/03/2018", "", "", ""));
            Versoes.Add(new VersaoModel(115, 42400000, "04.24.00.000", "06/02/2018", "", "", ""));
            Versoes.Add(new VersaoModel(114, 42300000, "04.23.00.000", "22/01/2018", "", "", ""));
            Versoes.Add(new VersaoModel(113, 42203000, "04.22.03.000", "13/12/2017", "", "", ""));
            Versoes.Add(new VersaoModel(112, 42202000, "04.22.02.000", "20/11/2017", "", "", ""));
            Versoes.Add(new VersaoModel(111, 42201000, "04.22.01.000", "14/11/2017", "", "", ""));
            Versoes.Add(new VersaoModel(110, 42200001, "04.22.00.001", "05/10/2017", "", "", ""));
            Versoes.Add(new VersaoModel(109, 42200000, "04.22.00.000", "29/09/2017", "", "", ""));
            Versoes.Add(new VersaoModel(108, 42100002, "04.21.00.002", "28/08/2017", "", "", ""));
            Versoes.Add(new VersaoModel(107, 42100001, "04.21.00.001", "16/08/2017", "", "", ""));
            Versoes.Add(new VersaoModel(106, 42100000, "04.21.00.000", "09/08/2017", "", "", ""));
            Versoes.Add(new VersaoModel(105, 42001000, "04.20.01.000", "26/07/2017", "", "", ""));
            Versoes.Add(new VersaoModel(104, 42000001, "04.20.00.001", "16/07/2017", "", "", ""));
            Versoes.Add(new VersaoModel(103, 42000000, "04.20.00.000", "07/07/2017", "", "", ""));
            Versoes.Add(new VersaoModel(102, 41902000, "04.19.02.000", "22/06/2017", "", "", ""));
            Versoes.Add(new VersaoModel(101, 41901000, "04.19.01.000", "19/05/2017", "", "", ""));
            Versoes.Add(new VersaoModel(100, 41900000, "04.19.00.000", "08/05/2017", "", "", ""));
            Versoes.Add(new VersaoModel(99, 41800000, "04.18.00.000", "12/04/2017", "", "", ""));
            Versoes.Add(new VersaoModel(98, 41701000, "04.17.01.000", "06/04/2017", "", "", ""));
            Versoes.Add(new VersaoModel(97, 41700000, "04.17.00.000", "01/03/2017", "", "", ""));
            Versoes.Add(new VersaoModel(96, 41600000, "04.16.00.000", "27/01/2017", "", "", ""));
            Versoes.Add(new VersaoModel(95, 41502001, "04.15.02.001", "02/12/2016", "", "", ""));
            Versoes.Add(new VersaoModel(94, 41501000, "04.15.01.000", "17/11/2016", "", "", ""));
            Versoes.Add(new VersaoModel(93, 41500000, "04.15.00.000", "27/10/2016", "", "", ""));
            Versoes.Add(new VersaoModel(92, 41400001, "04.14.00.001", "21/10/2016", "", "", ""));
            Versoes.Add(new VersaoModel(91, 41400000, "04.14.00.000", "04/10/2016", "", "", ""));
            Versoes.Add(new VersaoModel(90, 41301001, "04.13.01.001", "27/09/2016", "", "", ""));
            Versoes.Add(new VersaoModel(89, 41301000, "04.13.01.000", "26/09/2016", "", "", ""));
            Versoes.Add(new VersaoModel(88, 41300001, "04.13.00.001", "22/09/2016", "", "", ""));
            Versoes.Add(new VersaoModel(87, 41300000, "04.13.00.000", "17/09/2016", "", "", ""));
            Versoes.Add(new VersaoModel(86, 41214000, "04.12.14.000", "02/08/2016", "", "", ""));
            Versoes.Add(new VersaoModel(85, 41213000, "04.12.13.000", "25/07/2016", "", "", ""));
            Versoes.Add(new VersaoModel(84, 41212000, "04.12.12.000", "12/07/2016", "", "", ""));
            Versoes.Add(new VersaoModel(83, 41211000, "04.12.11.000", "30/06/2016", "", "", ""));
            Versoes.Add(new VersaoModel(82, 41210000, "04.12.10.000", "01/06/2016", "", "", ""));
            Versoes.Add(new VersaoModel(81, 41209001, "04.12.09.001", "23/05/2016", "", "", ""));
            Versoes.Add(new VersaoModel(80, 41209000, "04.12.09.000", "23/05/2016", "", "", ""));
            Versoes.Add(new VersaoModel(79, 41208001, "04.12.08.001", "09/05/2016", "", "", ""));
            Versoes.Add(new VersaoModel(78, 41207000, "04.12.07.000", "20/04/2016", "", "", ""));
            Versoes.Add(new VersaoModel(77, 41206001, "04.12.06.001", "30/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(76, 41206000, "04.12.06.000", "30/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(75, 41205006, "04.12.05.006", "18/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(74, 41205005, "04.12.05.005", "16/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(73, 41205004, "04.12.05.004", "11/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(72, 41205003, "04.12.05.003", "01/03/2016", "", "", ""));
            Versoes.Add(new VersaoModel(71, 41205002, "04.12.05.002", "25/02/2016", "", "", ""));
            Versoes.Add(new VersaoModel(70, 41205001, "04.12.05.001", "17/02/2016", "", "", ""));
            Versoes.Add(new VersaoModel(69, 41205000, "04.12.05.000", "10/02/2016", "", "", ""));
            Versoes.Add(new VersaoModel(68, 41204000, "04.12.04.000", "22/01/2016", "", "", ""));
            Versoes.Add(new VersaoModel(67, 41203000, "04.12.03.000", "08/01/2016", "", "", ""));
            Versoes.Add(new VersaoModel(66, 41202002, "04.12.02.002", "04/12/2015", "", "", ""));
            Versoes.Add(new VersaoModel(65, 41202001, "04.12.02.001", "27/11/2015", "", "", ""));
            Versoes.Add(new VersaoModel(64, 41202000, "04.12.02.000", "26/11/2015", "", "", ""));
            Versoes.Add(new VersaoModel(63, 41201000, "04.12.01.000", "30/10/2015", "", "", ""));
            Versoes.Add(new VersaoModel(62, 41200000, "04.12.00.000", "09/10/2015", "", "", ""));
            Versoes.Add(new VersaoModel(61, 41104000, "04.11.04.000", "19/08/2015", "", "", ""));
            Versoes.Add(new VersaoModel(60, 41103004, "04.11.03.004", "10/08/2015", "", "", ""));
            Versoes.Add(new VersaoModel(59, 41102003, "04.11.02.003", "31/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(58, 41102002, "04.11.02.002", "29/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(57, 41102001, "04.11.02.001", "27/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(56, 41102000, "04.11.02.000", "24/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(55, 41101002, "04.11.01.002", "21/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(54, 41101001, "04.11.01.001", "07/07/2015", "", "", ""));
            Versoes.Add(new VersaoModel(53, 41100001, "04.11.00.001", "25/06/2015", "", "", ""));
            Versoes.Add(new VersaoModel(52, 41100000, "04.11.00.000", "23/06/2015", "", "", ""));
            Versoes.Add(new VersaoModel(51, 41002000, "04.10.02.000", "23/04/2015", "", "", ""));
            Versoes.Add(new VersaoModel(50, 41001005, "04.10.01.005", "09/04/2015", "", "", ""));
            Versoes.Add(new VersaoModel(49, 41001004, "04.10.01.004", "08/04/2015", "", "", ""));
            Versoes.Add(new VersaoModel(48, 41001001, "04.10.01.001", "20/03/2015", "", "", ""));
            Versoes.Add(new VersaoModel(47, 41001000, "04.10.01.000", "20/03/2015", "", "", ""));
            Versoes.Add(new VersaoModel(46, 41000000, "04.10.00.000", "18/03/2015", "", "", ""));
            Versoes.Add(new VersaoModel(45, 40902000, "04.09.02.000", "13/02/2015", "", "", ""));
            Versoes.Add(new VersaoModel(44, 40900000, "04.09.00.000", "22/12/2014", "", "", ""));
            Versoes.Add(new VersaoModel(43, 40802001, "04.08.02.001", "17/11/2014", "", "", ""));
            Versoes.Add(new VersaoModel(42, 40802000, "04.08.02.000", "11/11/2014", "", "", ""));
            Versoes.Add(new VersaoModel(41, 40801000, "04.08.01.000", "26/09/2014", "", "", ""));
            Versoes.Add(new VersaoModel(40, 40800001, "04.08.00.001", "27/08/2014", "", "", ""));
            Versoes.Add(new VersaoModel(39, 40800000, "04.08.00.000", "20/08/2014", "", "", ""));
            Versoes.Add(new VersaoModel(38, 40705000, "04.07.05.000", "06/06/2014", "", "", ""));
            Versoes.Add(new VersaoModel(37, 40704003, "04.07.04.003", "16/05/2014", "", "", ""));
            Versoes.Add(new VersaoModel(36, 40704002, "04.07.04.002", "06/05/2014", "", "", ""));
            Versoes.Add(new VersaoModel(35, 40704001, "04.07.04.001", "25/04/2014", "", "", ""));
            Versoes.Add(new VersaoModel(34, 40704000, "04.07.04.000", "24/04/2014", "", "", ""));
            Versoes.Add(new VersaoModel(33, 40703000, "04.07.03.000", "20/02/2014", "", "", ""));
            Versoes.Add(new VersaoModel(32, 40702001, "04.07.02.001", "17/02/2014", "", "", ""));
            Versoes.Add(new VersaoModel(31, 40702000, "04.07.02.000", "14/02/2014", "", "", ""));
            Versoes.Add(new VersaoModel(30, 40701002, "04.07.01.002", "13/12/2013", "", "", ""));
            Versoes.Add(new VersaoModel(29, 40701001, "04.07.01.001", "12/12/2013", "", "", ""));
            Versoes.Add(new VersaoModel(28, 40701000, "04.07.01.000", "02/12/2013", "", "", ""));
            Versoes.Add(new VersaoModel(27, 40700002, "04.07.00.002", "16/10/2013", "", "", ""));
            Versoes.Add(new VersaoModel(26, 40700001, "04.07.00.001", "09/10/2013", "", "", ""));
            Versoes.Add(new VersaoModel(25, 40700000, "04.07.00.000", "26/09/2013", "", "", ""));
            Versoes.Add(new VersaoModel(24, 40602003, "04.06.02.003", "23/08/2013", "", "", ""));
            Versoes.Add(new VersaoModel(23, 40602002, "04.06.02.002", "15/08/2013", "", "", ""));
            Versoes.Add(new VersaoModel(22, 40602001, "04.06.02.001", "31/07/2013", "", "", ""));
            Versoes.Add(new VersaoModel(21, 40602000, "04.06.02.000", "25/07/2013", "", "", ""));
            Versoes.Add(new VersaoModel(20, 40601000, "04.06.01.000", "17/07/2013", "", "", ""));
            Versoes.Add(new VersaoModel(19, 40600000, "04.06.00.000", "10/07/2013", "", "", ""));
            Versoes.Add(new VersaoModel(18, 40501000, "04.05.01.000", "21/09/2012", "", "", ""));
            Versoes.Add(new VersaoModel(17, 40500000, "04.05.00.000", "21/06/2012", "", "", ""));
            Versoes.Add(new VersaoModel(16, 40404001, "04.04.04.001", "03/04/2012", "", "", ""));
            Versoes.Add(new VersaoModel(15, 40404000, "04.04.04.000", "10/02/2012", "", "", ""));
            Versoes.Add(new VersaoModel(14, 40403002, "04.04.03.002", "03/02/2012", "", "", ""));
            Versoes.Add(new VersaoModel(13, 40403001, "04.04.03.001", "02/02/2012", "", "", ""));
            Versoes.Add(new VersaoModel(12, 40403000, "04.04.03.000", "31/01/2012", "", "", ""));
            Versoes.Add(new VersaoModel(11, 40402000, "04.04.02.000", "20/12/2011", "", "", ""));
            Versoes.Add(new VersaoModel(10, 40401001, "04.04.01.001", "30/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(9, 40401000, "04.04.01.000", "22/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(8, 40400007, "04.04.00.007", "14/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(7, 40400006, "04.04.00.006", "09/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(6, 40400005, "04.04.00.005", "08/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(5, 40400004, "04.04.00.004", "07/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(4, 40400003, "04.04.00.003", "03/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(3, 40400002, "04.04.00.002", "01/11/2011", "", "", ""));
            Versoes.Add(new VersaoModel(2, 40400001, "04.04.00.001", "31/10/2011", "", "", ""));
            Versoes.Add(new VersaoModel(1, 40400000, "04.04.00.000", "27/10/2011", "", "", ""));            
            return Versoes;
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
