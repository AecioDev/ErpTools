using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AtualizaERP.Classes
{
    [System.Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class ListaPlanejamento
    {
        [XmlElement("Plano")]
        public List<Plano> ListaDePlanejamentos = new List<Plano>();
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]

    public partial class Plano
    {
        private string estruturaField;

        private int codigoField;

        private string nomenclaturaField;

        private string dessubtotField;

        private string janeiroField;

        private string totalJanField;

        private string subTotJanField;

        private string fevereiroField;

        private string totalFevField;

        private string subTotFevField;

        private string marcoField;

        private string totalMarField;

        private string subTotMarField;

        private string abrilField;

        private string totalAbrField;

        private string subTotAbrField;

        private string maioField;

        private string totalMaiField;

        private string subTotMaiField;

        private string junhoField;

        private string totalJunField;

        private string subTotJunField;

        private string julhoField;

        private string totalJulField;

        private string subTotJulField;

        private string agostoField;

        private string totalAgoField;

        private string subTotAgoField;

        private string setembroField;

        private string totalSetField;

        private string subTotSetField;

        private string outubroField;

        private string totalOutField;

        private string subTotOutField;

        private string novembroField;

        private string totalNovField;

        private string subTotNovField;

        private string dezembroField;

        private string totalDezField;

        private string subTotDezField;

        private string totalGeralField;

        private string totalGerField;

        private string subTotGerField;

        private string mediaGeralField;

        private string totalMedField;

        private string subTotMedField;

        private string receitaGeralField;

        private string totalRecField;

        private string subTotRecField;

        private string coluna200Field;

        private string coluna202Field;
                
        /// <remarks/>
        public string Estrutura
        {
            get
            {
                return this.estruturaField;
            }
            set
            {
                this.estruturaField = value;
            }
        }

        /// <remarks/>
        public int Codigo
        {
            get
            {
                return this.codigoField;
            }
            set
            {
                this.codigoField = value;
            }
        }

        /// <remarks/>
        public string Nomenclatura
        {
            get
            {
                return this.nomenclaturaField;
            }
            set
            {
                this.nomenclaturaField = value;
            }
        }

        /// <remarks/>
        public string dessubtot
        {
            get
            {
                return this.dessubtotField;
            }
            set
            {
                this.dessubtotField = value;
            }
        }

        /// <remarks/>
        public string Janeiro
        {
            get
            {
                return this.janeiroField;
            }
            set
            {
                this.janeiroField = value;
            }
        }

        /// <remarks/>
        public string totalJan
        {
            get
            {
                return this.totalJanField;
            }
            set
            {
                this.totalJanField = value;
            }
        }

        /// <remarks/>
        public string subTotJan
        {
            get
            {
                return this.subTotJanField;
            }
            set
            {
                this.subTotJanField = value;
            }
        }

        /// <remarks/>
        public string Fevereiro
        {
            get
            {
                return this.fevereiroField;
            }
            set
            {
                this.fevereiroField = value;
            }
        }

        /// <remarks/>
        public string totalFev
        {
            get
            {
                return this.totalFevField;
            }
            set
            {
                this.totalFevField = value;
            }
        }

        /// <remarks/>
        public string subTotFev
        {
            get
            {
                return this.subTotFevField;
            }
            set
            {
                this.subTotFevField = value;
            }
        }

        /// <remarks/>
        public string Marco
        {
            get
            {
                return this.marcoField;
            }
            set
            {
                this.marcoField = value;
            }
        }

        /// <remarks/>
        public string totalMar
        {
            get
            {
                return this.totalMarField;
            }
            set
            {
                this.totalMarField = value;
            }
        }

        /// <remarks/>
        public string subTotMar
        {
            get
            {
                return this.subTotMarField;
            }
            set
            {
                this.subTotMarField = value;
            }
        }

        /// <remarks/>
        public string Abril
        {
            get
            {
                return this.abrilField;
            }
            set
            {
                this.abrilField = value;
            }
        }

        /// <remarks/>
        public string totalAbr
        {
            get
            {
                return this.totalAbrField;
            }
            set
            {
                this.totalAbrField = value;
            }
        }

        /// <remarks/>
        public string subTotAbr
        {
            get
            {
                return this.subTotAbrField;
            }
            set
            {
                this.subTotAbrField = value;
            }
        }

        /// <remarks/>
        public string Maio
        {
            get
            {
                return this.maioField;
            }
            set
            {
                this.maioField = value;
            }
        }

        /// <remarks/>
        public string totalMai
        {
            get
            {
                return this.totalMaiField;
            }
            set
            {
                this.totalMaiField = value;
            }
        }

        /// <remarks/>
        public string subTotMai
        {
            get
            {
                return this.subTotMaiField;
            }
            set
            {
                this.subTotMaiField = value;
            }
        }

        /// <remarks/>
        public string Junho
        {
            get
            {
                return this.junhoField;
            }
            set
            {
                this.junhoField = value;
            }
        }

        /// <remarks/>
        public string totalJun
        {
            get
            {
                return this.totalJunField;
            }
            set
            {
                this.totalJunField = value;
            }
        }

        /// <remarks/>
        public string subTotJun
        {
            get
            {
                return this.subTotJunField;
            }
            set
            {
                this.subTotJunField = value;
            }
        }

        /// <remarks/>
        public string Julho
        {
            get
            {
                return this.julhoField;
            }
            set
            {
                this.julhoField = value;
            }
        }

        /// <remarks/>
        public string totalJul
        {
            get
            {
                return this.totalJulField;
            }
            set
            {
                this.totalJulField = value;
            }
        }

        /// <remarks/>
        public string subTotJul
        {
            get
            {
                return this.subTotJulField;
            }
            set
            {
                this.subTotJulField = value;
            }
        }

        /// <remarks/>
        public string Agosto
        {
            get
            {
                return this.agostoField;
            }
            set
            {
                this.agostoField = value;
            }
        }

        /// <remarks/>
        public string totalAgo
        {
            get
            {
                return this.totalAgoField;
            }
            set
            {
                this.totalAgoField = value;
            }
        }

        /// <remarks/>
        public string subTotAgo
        {
            get
            {
                return this.subTotAgoField;
            }
            set
            {
                this.subTotAgoField = value;
            }
        }

        /// <remarks/>
        public string Setembro
        {
            get
            {
                return this.setembroField;
            }
            set
            {
                this.setembroField = value;
            }
        }

        /// <remarks/>
        public string totalSet
        {
            get
            {
                return this.totalSetField;
            }
            set
            {
                this.totalSetField = value;
            }
        }

        /// <remarks/>
        public string subTotSet
        {
            get
            {
                return this.subTotSetField;
            }
            set
            {
                this.subTotSetField = value;
            }
        }

        /// <remarks/>
        public string Outubro
        {
            get
            {
                return this.outubroField;
            }
            set
            {
                this.outubroField = value;
            }
        }

        /// <remarks/>
        public string totalOut
        {
            get
            {
                return this.totalOutField;
            }
            set
            {
                this.totalOutField = value;
            }
        }

        /// <remarks/>
        public string subTotOut
        {
            get
            {
                return this.subTotOutField;
            }
            set
            {
                this.subTotOutField = value;
            }
        }

        /// <remarks/>
        public string Novembro
        {
            get
            {
                return this.novembroField;
            }
            set
            {
                this.novembroField = value;
            }
        }

        /// <remarks/>
        public string totalNov
        {
            get
            {
                return this.totalNovField;
            }
            set
            {
                this.totalNovField = value;
            }
        }

        /// <remarks/>
        public string subTotNov
        {
            get
            {
                return this.subTotNovField;
            }
            set
            {
                this.subTotNovField = value;
            }
        }

        /// <remarks/>
        public string Dezembro
        {
            get
            {
                return this.dezembroField;
            }
            set
            {
                this.dezembroField = value;
            }
        }

        /// <remarks/>
        public string totalDez
        {
            get
            {
                return this.totalDezField;
            }
            set
            {
                this.totalDezField = value;
            }
        }

        /// <remarks/>
        public string subTotDez
        {
            get
            {
                return this.subTotDezField;
            }
            set
            {
                this.subTotDezField = value;
            }
        }

        /// <remarks/>
        public string totalGeral
        {
            get
            {
                return this.totalGeralField;
            }
            set
            {
                this.totalGeralField = value;
            }
        }

        /// <remarks/>
        public string totalGer
        {
            get
            {
                return this.totalGerField;
            }
            set
            {
                this.totalGerField = value;
            }
        }

        /// <remarks/>
        public string subTotGer
        {
            get
            {
                return this.subTotGerField;
            }
            set
            {
                this.subTotGerField = value;
            }
        }

        /// <remarks/>
        public string mediaGeral
        {
            get
            {
                return this.mediaGeralField;
            }
            set
            {
                this.mediaGeralField = value;
            }
        }

        /// <remarks/>
        public string totalMed
        {
            get
            {
                return this.totalMedField;
            }
            set
            {
                this.totalMedField = value;
            }
        }

        /// <remarks/>
        public string subTotMed
        {
            get
            {
                return this.subTotMedField;
            }
            set
            {
                this.subTotMedField = value;
            }
        }

        /// <remarks/>
        public string receitaGeral
        {
            get
            {
                return this.receitaGeralField;
            }
            set
            {
                this.receitaGeralField = value;
            }
        }

        /// <remarks/>
        public string totalRec
        {
            get
            {
                return this.totalRecField;
            }
            set
            {
                this.totalRecField = value;
            }
        }

        /// <remarks/>
        public string subTotRec
        {
            get
            {
                return this.subTotRecField;
            }
            set
            {
                this.subTotRecField = value;
            }
        }

        /// <remarks/>
        public string coluna200
        {
            get
            {
                return this.coluna200Field;
            }
            set
            {
                this.coluna200Field = value;
            }
        }

        /// <remarks/>
        public string coluna202
        {
            get
            {
                return this.coluna202Field;
            }
            set
            {
                this.coluna202Field = value;
            }
        }
    }
}