using System;

namespace GtiTeste.API.Models
{
    public class EstadoModel
    {
        public EstadoModel()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
    }
}