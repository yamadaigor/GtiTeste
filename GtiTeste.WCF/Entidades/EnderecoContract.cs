using System;
using System.Runtime.Serialization;

namespace GtiTeste.WCF.Entidades
{
    [DataContract]
    public class EnderecoContract
    {
        private Guid id;

        [DataMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        private string cep;

        [DataMember]
        public string Cep
        {
            get { return cep; }
            set { cep = value; }
        }

        private string logradouro;

        [DataMember]
        public string Logradouro
        {
            get { return logradouro; }
            set { logradouro = value; }
        }

        private string numero;

        [DataMember]
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string complemento;
        [DataMember]
        public string Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private string bairro;
        [DataMember]
        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }

        private string cidade;
        [DataMember]
        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }

        private string uf;
        [DataMember]
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }
    }
}
