using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GtiTeste.WCF.DTO
{
    [DataContract]
    public class RetornoOperacaoDTO
    {
        private bool operacaoValida;

        [DataMember]
        public bool OperacaoValida
        {
            get { return operacaoValida; }
            set { operacaoValida = value; }
        }
        private List<string> mensagens;

        [DataMember]
        public List<string> Mensagens
        {
            get { return mensagens; }
            set { mensagens = value; }
        }
    }
}