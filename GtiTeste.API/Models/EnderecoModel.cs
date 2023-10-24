using System;
using System.ComponentModel.DataAnnotations;

namespace GtiTeste.API.Models
{
    public class EnderecoModel
    {
        public EnderecoModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}