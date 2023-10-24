using System.Collections.Generic;

namespace GtiTeste.Business.DTO
{
    public class RetornoOperacaoDTO
    {
        public RetornoOperacaoDTO()
        {
            OperacaoValida = true;
            Mensagens = new List<string>();
        }
        public bool OperacaoValida { get; set; }
        public List<string> Mensagens { get; set; }
    }
}
