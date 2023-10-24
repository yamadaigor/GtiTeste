using System;

namespace GtiTeste.AppMVC.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string UF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}