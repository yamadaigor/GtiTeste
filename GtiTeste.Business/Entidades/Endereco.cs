using GtiTeste.Business.Base;

namespace GtiTeste.Business.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        // Para mapeamento do EntityFramework
        public Cliente Cliente { get; set; }
    }
}
