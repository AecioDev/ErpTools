using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtualizaERP.Classes
{
    //Replace 1 - SdtListaNotas.SdtListaNotasItem -> Nota
    //Replace 2 - SdtListaNotas -> ListaNotas
    //Replace 3 - SdtTitulosExcel -> Titulos

    [System.Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ListaTitulos
    {
        [XmlElement("Titulo")]
        public List<Titulo> ListaDeTitulos = new List<Titulo>();
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Titulo
    {

        private int seqtitField;

        private string tiptitField;

        private string numdoctitField;

        private int pardoctitField;

        private string txtpartitField;

        private int codcliforField;

        private string nomcliforField;

        private DateTime datventitField;

        private decimal valtitField;

        private decimal saltitField;

        private int diasventitField;

        private string numbantitField;

        private DateTime emititField;

        private string datultpagField;

        private int codventitField;

        private string nomventitField;

        private int codloccobField;

        private string desloccobField;

        private string espdoctitField;

        private string acestatitField;

        private string acedattitField;

        private string aceusutitField;

        private int renorigField;

        private string obstitField;

        private DateTime ventitField;

        private string orgtitField;

        private string codimpcliField;

        private string cnpjcliforField;

        private decimal valtitborField;

        /// <remarks/>
        public int seqtit
        {
            get
            {
                return this.seqtitField;
            }
            set
            {
                this.seqtitField = value;
            }
        }

        /// <remarks/>
        public string tiptit
        {
            get
            {
                return this.tiptitField;
            }
            set
            {
                this.tiptitField = value;
            }
        }

        /// <remarks/>
        public string numdoctit
        {
            get
            {
                return this.numdoctitField;
            }
            set
            {
                this.numdoctitField = value;
            }
        }

        /// <remarks/>
        public int pardoctit
        {
            get
            {
                return this.pardoctitField;
            }
            set
            {
                this.pardoctitField = value;
            }
        }

        /// <remarks/>
        public string txtpartit
        {
            get
            {
                return this.txtpartitField;
            }
            set
            {
                this.txtpartitField = value;
            }
        }

        /// <remarks/>
        public int codclifor
        {
            get
            {
                return this.codcliforField;
            }
            set
            {
                this.codcliforField = value;
            }
        }

        /// <remarks/>
        public string nomclifor
        {
            get
            {
                return this.nomcliforField;
            }
            set
            {
                this.nomcliforField = value;
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime datventit
        {
            get
            {
                return this.datventitField;
            }
            set
            {
                this.datventitField = value;
            }
        }

        /// <remarks/>
        public decimal valtit
        {
            get
            {
                return this.valtitField;
            }
            set
            {
                this.valtitField = value;
            }
        }

        /// <remarks/>
        public decimal saltit
        {
            get
            {
                return this.saltitField;
            }
            set
            {
                this.saltitField = value;
            }
        }

        /// <remarks/>
        public int diasventit
        {
            get
            {
                return this.diasventitField;
            }
            set
            {
                this.diasventitField = value;
            }
        }

        /// <remarks/>
        public string numbantit
        {
            get
            {
                return this.numbantitField;
            }
            set
            {
                this.numbantitField = value;
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime emitit
        {
            get
            {
                return this.emititField;
            }
            set
            {
                this.emititField = value;
            }
        }

        /// <remarks/>
        public string datultpag
        {
            get
            {
                return this.datultpagField;
            }
            set
            {
                this.datultpagField = value;
            }
        }

        /// <remarks/>
        public int codventit
        {
            get
            {
                return this.codventitField;
            }
            set
            {
                this.codventitField = value;
            }
        }

        /// <remarks/>
        public string nomventit
        {
            get
            {
                return this.nomventitField;
            }
            set
            {
                this.nomventitField = value;
            }
        }

        /// <remarks/>
        public int codloccob
        {
            get
            {
                return this.codloccobField;
            }
            set
            {
                this.codloccobField = value;
            }
        }

        /// <remarks/>
        public string desloccob
        {
            get
            {
                return this.desloccobField;
            }
            set
            {
                this.desloccobField = value;
            }
        }

        /// <remarks/>
        public string espdoctit
        {
            get
            {
                return this.espdoctitField;
            }
            set
            {
                this.espdoctitField = value;
            }
        }

        /// <remarks/>
        public string acestatit
        {
            get
            {
                return this.acestatitField;
            }
            set
            {
                this.acestatitField = value;
            }
        }

        /// <remarks/>
        public string acedattit
        {
            get
            {
                return this.acedattitField;
            }
            set
            {
                this.acedattitField = value;
            }
        }

        /// <remarks/>
        public string aceusutit
        {
            get
            {
                return this.aceusutitField;
            }
            set
            {
                this.aceusutitField = value;
            }
        }

        /// <remarks/>
        public int renorig
        {
            get
            {
                return this.renorigField;
            }
            set
            {
                this.renorigField = value;
            }
        }

        /// <remarks/>
        public string obstit
        {
            get
            {
                return this.obstitField;
            }
            set
            {
                this.obstitField = value;
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "date")]
        public DateTime ventit
        {
            get
            {
                return this.ventitField;
            }
            set
            {
                this.ventitField = value;
            }
        }

        /// <remarks/>
        public string orgtit
        {
            get
            {
                return this.orgtitField;
            }
            set
            {
                this.orgtitField = value;
            }
        }

        /// <remarks/>
        public string codimpcli
        {
            get
            {
                return this.codimpcliField;
            }
            set
            {
                this.codimpcliField = value;
            }
        }

        /// <remarks/>
        public string cnpjclifor
        {
            get
            {
                return this.cnpjcliforField;
            }
            set
            {
                this.cnpjcliforField = value;
            }
        }

        /// <remarks/>
        public decimal valtitbor
        {
            get
            {
                return this.valtitborField;
            }
            set
            {
                this.valtitborField = value;
            }
        }
    }


}