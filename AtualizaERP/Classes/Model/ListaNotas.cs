
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtualizaERP.Classes
{

    //Replace 1 - SdtListaNotas.SdtListaNotasItem -> Nota
    //Replace 2 - SdtListaNotas -> ListaNotas

    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public class ListaNotas
    {
        [XmlElement("Nota")]
        public List<Nota> ListaDeNotas = new List<Nota>();
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Nota
    {

        private int tipentsaiField;

        private int nroentsaiField;

        private string destipnotField;

        private DateTime datemientsaiField;

        private string serentsaiField;

        private int nfentsaiField;

        private int codcliforField;

        private string nomentsaiField;

        private decimal totgerfinentsaiField;

        private string staentsaiField;

        private int nfCupFisEntSaiField;

        private int nrorpsentsaiField;

        private string infcretercentsaiField;

        private DateTime datatufinentsaiField;

        private string plaveientsaiField;

        private string ufplaveientsaiField;

        private int codtraField;

        private string nomtraField;

        private string obsentsaiField;

        /// <remarks/>
        public int tipentsai
        {
            get
            {
                return tipentsaiField;
            }
            set
            {
                tipentsaiField = value;
            }
        }

        /// <remarks/>
        public int nroentsai
        {
            get
            {
                return nroentsaiField;
            }
            set
            {
                nroentsaiField = value;
            }
        }

        /// <remarks/>
        public string destipnot
        {
            get
            {
                return destipnotField;
            }
            set
            {
                destipnotField = value;
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime datemientsai
        {
            get
            {
                return datemientsaiField;
            }
            set
            {
                datemientsaiField = value;
            }
        }

        /// <remarks/>
        public string serentsai
        {
            get
            {
                return serentsaiField;
            }
            set
            {
                serentsaiField = value;
            }
        }

        /// <remarks/>
        public int nfentsai
        {
            get
            {
                return nfentsaiField;
            }
            set
            {
                nfentsaiField = value;
            }
        }

        /// <remarks/>
        public int codclifor
        {
            get
            {
                return codcliforField;
            }
            set
            {
                codcliforField = value;
            }
        }

        /// <remarks/>
        public string nomentsai
        {
            get
            {
                return nomentsaiField;
            }
            set
            {
                nomentsaiField = value;
            }
        }

        /// <remarks/>
        public decimal totgerfinentsai
        {
            get
            {
                return totgerfinentsaiField;
            }
            set
            {
                totgerfinentsaiField = value;
            }
        }

        /// <remarks/>
        public string staentsai
        {
            get
            {
                return staentsaiField;
            }
            set
            {
                staentsaiField = value;
            }
        }

        /// <remarks/>
        public int nfCupFisEntSai
        {
            get
            {
                return nfCupFisEntSaiField;
            }
            set
            {
                nfCupFisEntSaiField = value;
            }
        }

        /// <remarks/>
        public int nrorpsentsai
        {
            get
            {
                return nrorpsentsaiField;
            }
            set
            {
                nrorpsentsaiField = value;
            }
        }

        /// <remarks/>
        public string infcretercentsai
        {
            get
            {
                return infcretercentsaiField;
            }
            set
            {
                infcretercentsaiField = value;
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime datatufinentsai
        {
            get
            {
                return datatufinentsaiField;
            }
            set
            {
                datatufinentsaiField = value;
            }
        }

        /// <remarks/>
        public string plaveientsai
        {
            get
            {
                return plaveientsaiField;
            }
            set
            {
                plaveientsaiField = value;
            }
        }

        /// <remarks/>
        public string ufplaveientsai
        {
            get
            {
                return ufplaveientsaiField;
            }
            set
            {
                ufplaveientsaiField = value;
            }
        }

        /// <remarks/>
        public int codtra
        {
            get
            {
                return codtraField;
            }
            set
            {
                codtraField = value;
            }
        }

        /// <remarks/>
        public string nomtra
        {
            get
            {
                return nomtraField;
            }
            set
            {
                nomtraField = value;
            }
        }

        /// <remarks/>
        public string obsentsai
        {
            get
            {
                return obsentsaiField;
            }
            set
            {
                obsentsaiField = value;
            }
        }
    }

}
