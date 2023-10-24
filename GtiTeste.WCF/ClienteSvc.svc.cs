using GtiTeste.Business.DTO;
using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces;
using GtiTeste.Business.Interfaces.Repository;
using GtiTeste.Business.Interfaces.Services;
using GtiTeste.Business.Services;
using GtiTeste.Data.Repository;
using GtiTeste.WCF.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GtiTeste.WCF
{
    public class ClienteSvc : IClienteSvc
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IClienteService _clienteService;

        #region Injeção de dependência
        //private readonly IMapper _mapper;
        //public ClienteSvc(IClienteRepository clienteRepository,
        //                  IMapper mapper)
        //{
        //    _clienteRepository = clienteRepository;
        //    _mapper = mapper;
        //}
        #endregion

        public ClienteSvc()
        {
            // Mesmo não sendo uma boa prática, foi implementada dessa forma, pois não funcionou a injeção de dependência
            // Perdi muito tempo tentando resolver e não funcionou.
            var context = new Data.Data.GtiDbContext();
            _clienteRepository = new ClienteRepository(context);
            _enderecoRepository = new EnderecoRepository(context);
            _estadoRepository = new EstadoRepository(context);
            _clienteService = new ClienteService(_clienteRepository, _enderecoRepository);
        }

        public List<ClienteContract> ObterClientes(string cpf, string nome)
        {
            var clientes = new List<ClienteContract>();
            var clientesBancoDados = _clienteRepository.ObterRegistros(c => (string.IsNullOrEmpty(cpf) || c.Cpf == cpf)
                                                               && (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)));

            if (clientesBancoDados.Any())
            {
                foreach (var clienteBd in clientesBancoDados)
                {
                    clientes.Add(MapToClienteContract(clienteBd));
                }
            }
            return clientes;
        }

        public RetornoOperacaoDTO Incluir(ClienteContract clienteContract)
        {
            var cliente = MapToCliente(clienteContract);
            var retorno = _clienteService.Incluir(cliente);

            return retorno;
        }

        public RetornoOperacaoDTO Alterar(Guid Id, ClienteContract clienteContract)
        {
            var retorno = new RetornoOperacaoDTO();

            if (Id != clienteContract.Id)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Cliente não encontrado");
                return retorno;
            }

            var cliente = MapToCliente(clienteContract);

            retorno = _clienteService.Atualizar(cliente);

            return retorno;
        }

        public RetornoOperacaoDTO Excluir(Guid Id)
        {
            var retorno = new RetornoOperacaoDTO();
            var cliente = _clienteRepository.ObterClienteEndereco(Id);

            if (cliente == null)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Cliente não encontrado");
            }
            retorno = _clienteService.Excluir(Id);

            return retorno;
        }

        public ClienteContract Detalhar(Guid Id)
        {
            var clienteContract = new ClienteContract();
            var cliente = _clienteRepository.ObterClienteEndereco(Id);

            if (cliente != null)
                clienteContract = MapToClienteContract(cliente);

            return clienteContract;
        }
        public List<EstadoContract> ObterEstados()
        {
            var estados = new List<EstadoContract>();
            var estadosBancoDados = _estadoRepository.ObterTodosRegistros().ToList();

            if (estadosBancoDados.Any())
            {
                foreach (var estadoBd in estadosBancoDados)
                {
                    estados.Add(MapToEstadoContract(estadoBd));
                }
            }
            return estados.OrderBy(x=> x.Sigla).ToList();
        }

        // Métodos "alternativos", pois a injeção de dependência não funcionou.
        private ClienteContract MapToClienteContract(Cliente cliente)
        {
            return new ClienteContract()
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                RG = cliente.RG,
                DataExpedicao = cliente.DataExpedicao,
                OrgaoExpedicao = cliente.OrgaoExpedicao,
                UF = cliente.UF,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                EstadoCivil = cliente.EstadoCivil,
                Endereco = new EnderecoContract()
                {
                    Id = cliente.Endereco.Id,
                    Cep = cliente.Endereco.Cep,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    UF = cliente.Endereco.UF
                }
            };
        }

        private Cliente MapToCliente(ClienteContract cliente)
        {
            return new Cliente()
            {
                Id = cliente.Id,
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                RG = cliente.RG,
                DataExpedicao = cliente.DataExpedicao,
                OrgaoExpedicao = cliente.OrgaoExpedicao,
                UF = cliente.UF,
                DataNascimento = cliente.DataNascimento,
                Sexo = cliente.Sexo,
                EstadoCivil = cliente.EstadoCivil,
                Endereco = new Endereco()
                {
                    Id = cliente.Endereco.Id,
                    Cep = cliente.Endereco.Cep,
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Complemento = cliente.Endereco.Complemento,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    UF = cliente.Endereco.UF
                }
            };
        }

        private EstadoContract MapToEstadoContract(Estado estado)
        {
            return new EstadoContract()
            {
                Id = estado.Id,
                Sigla = estado.Sigla,
                Descricao = estado.Descricao
            };
        }
    }
}
