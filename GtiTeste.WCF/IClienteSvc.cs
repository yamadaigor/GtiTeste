using GtiTeste.Business.DTO;
using GtiTeste.WCF.Entidades;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace GtiTeste.WCF
{
    [ServiceContract]
    public interface IClienteSvc
    {
        [OperationContract]
        List<ClienteContract> ObterClientes(string cpf, string nome);

        [OperationContract]
        RetornoOperacaoDTO Incluir(ClienteContract cliente);

        [OperationContract]
        RetornoOperacaoDTO Alterar(Guid Id, ClienteContract cliente);

        [OperationContract]
        RetornoOperacaoDTO Excluir(Guid Id);

        [OperationContract]
        ClienteContract Detalhar(Guid Id);

        [OperationContract]
        List<EstadoContract> ObterEstados();
    }
}
