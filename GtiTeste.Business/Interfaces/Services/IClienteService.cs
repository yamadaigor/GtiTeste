using GtiTeste.Business.DTO;
using GtiTeste.Business.Entidades;
using System;

namespace GtiTeste.Business.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        RetornoOperacaoDTO Incluir(Cliente cliente);
        RetornoOperacaoDTO Atualizar(Cliente cliente);
        RetornoOperacaoDTO Excluir(Guid id);
    }
}
