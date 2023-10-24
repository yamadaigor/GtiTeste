using System;
using System.Runtime.Serialization;

namespace GtiTeste.WCF.Entidades
{
    [DataContract]
    public class ClienteContract
    {
        private Guid id;

        [DataMember]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        private string cpf;

        [DataMember]
        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        private string nome;

        [DataMember]
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string rg;

        [DataMember]
        public string RG
        {
            get { return rg; }
            set { rg = value; }
        }

        private DateTime dataExpedicao;
        [DataMember]
        public DateTime DataExpedicao
        {
            get { return dataExpedicao; }
            set { dataExpedicao = value; }
        }

        private string orgaoExpedicao;
        [DataMember]
        public string OrgaoExpedicao
        {
            get { return orgaoExpedicao; }
            set { orgaoExpedicao = value; }
        }

        private string uf;
        [DataMember]
        public string UF
        {
            get { return uf; }
            set { uf = value; }
        }

        private DateTime dataNascimento;
        [DataMember]
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        private string sexo;
        [DataMember]
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        private string estadoCivil;
        [DataMember]
        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        private EnderecoContract endereco;
        [DataMember]
        public EnderecoContract Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
    }
}
