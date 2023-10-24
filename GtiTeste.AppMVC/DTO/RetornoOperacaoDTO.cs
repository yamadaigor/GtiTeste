using System.Collections.Generic;

namespace GtiTeste.AppMVC.DTO
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