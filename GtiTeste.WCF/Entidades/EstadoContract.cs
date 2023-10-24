using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GtiTeste.WCF.Entidades
{
    [DataContract]
    public class EstadoContract
    {
        private Guid id;

        [DataMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string sigla;

        [DataMember]
        public string Sigla
        {
            get { return sigla; }
            set { sigla = value; }
        }

        private string descricao;

        [DataMember]
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}