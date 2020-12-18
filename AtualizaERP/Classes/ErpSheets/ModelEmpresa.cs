
namespace AtualizaERP.Classes
{
    public class ModelEmpresa
    {
        public int codcencus { get; set; }
        public string nomeEmp { get; set; }
        public byte[] logoEmp { get; set; }
        public bool logoOk { get; set; }

        public ModelEmpresa(){}

        public ModelEmpresa(int _cencus, string _nomeEmp, byte[] _logoEmp, bool _logoOk)
        {
            codcencus = _cencus;
            nomeEmp = _nomeEmp;
            logoEmp = _logoEmp;
            logoOk = _logoOk;
        }
    }
}
