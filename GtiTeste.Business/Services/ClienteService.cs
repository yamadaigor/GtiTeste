using GtiTeste.Business.Base;
using GtiTeste.Business.DTO;
using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces;
using GtiTeste.Business.Interfaces.Repository;
using GtiTeste.Business.Interfaces.Services;
using GtiTeste.Business.Validacoes;
using System;
using System.Linq;

namespace GtiTeste.Business.Services
{
    public class ClienteService : ServiceBase, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public ClienteService(IClienteRepository clienteRepository,
                              IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }

        public RetornoOperacaoDTO Incluir(Cliente cliente)
        {
            var retorno = new RetornoOperacaoDTO();

            try
            {
                cliente.Endereco.Id = cliente.Id;
                cliente.Endereco.Cliente = cliente;

                if(!string.IsNullOrEmpty(cliente.Cpf))
                cliente.Cpf = cliente.Cpf.Replace(".", "").Replace("-", "");

                retorno.OperacaoValida = Validar(cliente, new ClienteValidation()) &&
                                         Validar(cliente.Endereco, new EnderecoValidation());

                if (!retorno.OperacaoValida)
                {
                    retorno.Mensagens = MensagensErro;
                    return retorno;
                }

                if (ExisteCliente(cliente))
                    retorno.Mensagens = MensagensErro;

                _clienteRepository.Incluir(cliente);

            }
            catch (Exception)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Ocorreu um erro inesperado, tente novamente. Se o erro persistir, contate o Adminitrador do sistema.");
            }

            return retorno;
        }
        public RetornoOperacaoDTO Atualizar(Cliente cliente)
        {
            var retorno = new RetornoOperacaoDTO();
            try
            {
                if (!string.IsNullOrEmpty(cliente.Cpf))
                    cliente.Cpf = cliente.Cpf.Replace(".", "").Replace("-", "");
                
                retorno.OperacaoValida = Validar(cliente, new ClienteValidation()) &&
                                         Validar(cliente.Endereco, new EnderecoValidation());

                if (!retorno.OperacaoValida)
                {
                    retorno.Mensagens = MensagensErro;
                    return retorno;
                }

                if (ExisteCliente(cliente))
                    retorno.Mensagens = MensagensErro;

                cliente.Endereco.Id = cliente.Id;
                cliente.Endereco.Cliente = cliente;

                _clienteRepository.Atualizar(cliente);

                // por algum motivo não está atualizando o endereço.
                // não encontrei o problema a tempo, então estou forçando a alteração do endereço, também.
                _enderecoRepository.Atualizar(cliente.Endereco);
            }
            catch (Exception)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Ocorreu um erro inesperado, tente novamente. Se o erro persistir, contate o Adminitrador do sistema.");
            }

            return retorno;
        }

        public RetornoOperacaoDTO Excluir(Guid id)
        {
            var retorno = new RetornoOperacaoDTO();

            try
            {
                var clienteExclusao = _clienteRepository.ObterClienteEndereco(id);

                if (clienteExclusao.Endereco != null)
                    _enderecoRepository.Excluir(clienteExclusao.Endereco.Id);

                _clienteRepository.Excluir(clienteExclusao.Id);

                if (!retorno.OperacaoValida)
                    retorno.Mensagens = MensagensErro;

            }
            catch (Exception)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Ocorreu um erro inesperado, tente novamente. Se o erro persistir, contate o Adminitrador do sistema.");
            }

            return retorno;
        }

        public void Dispose()
        {
            _clienteRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        private bool ExisteCliente(Cliente cliente)
        {
            var clienteExistente = _clienteRepository.ObterRegistros(c => c.Cpf == cliente.Cpf && c.Id != cliente.Id);

            var clienteExiste = clienteExistente.Any();

            if (clienteExiste)
            {
                MensagensErro.Add("Um outro cliente já existe com mesmo CPF");
            }
            return clienteExiste;
        }
    }
}
