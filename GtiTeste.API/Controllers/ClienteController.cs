using AutoMapper;
using GtiTeste.API.Models;
using GtiTeste.Business.DTO;
using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces;
using GtiTeste.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;


namespace GtiTeste.API.Controllers
{
    public class ClienteController : ApiController
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService,
                                 IClienteRepository clienteRepository,
                                 IMapper mapper)
        {
            _clienteService = clienteService;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("obter-clientes")]
        public IEnumerable<ClienteModel> Get([FromUri] string cpf = null, [FromUri] string nome = null)
        {
            var clientesModel = new List<ClienteModel>();
            var clientes = _clienteRepository.ObterRegistros(c=> (string.IsNullOrEmpty(cpf) || c.Cpf == cpf) 
                                                               && (string.IsNullOrEmpty(nome) || c.Nome.Contains(nome)));

            if (clientes.Any())
                clientesModel = _mapper.Map<List<ClienteModel>>(clientes);

            return clientesModel;
        }

        [HttpGet]
        [Route("obter-cliente")]
        public ClienteModel Get(Guid id)
        {
            var clienteModel = new ClienteModel();
            var cliente = _clienteRepository.ObterClienteEndereco(id);

            if (cliente != null)
                clienteModel = _mapper.Map<ClienteModel>(cliente);

            return clienteModel;
        }

        [HttpPost]
        [Route("incluir-cliente")]
        public RetornoOperacaoDTO Incluir(ClienteModel clienteModel)
        {
            var retorno = new RetornoOperacaoDTO();
            var cliente = _mapper.Map<Cliente>(clienteModel);

            retorno = _clienteService.Incluir(cliente);

            return retorno;
        }

        [HttpPut]
        [Route("alterar-cliente")]
        public RetornoOperacaoDTO Alterar(ClienteModel clienteModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteModel);

            var retorno = _clienteService.Atualizar(cliente);

            return retorno;
        }

        [HttpDelete]
        [Route("excluir-cliente")]
        public RetornoOperacaoDTO Excluir(Guid id)
        {
            var retorno = new RetornoOperacaoDTO();
            var cliente = _clienteRepository.ObterClienteEndereco(id);

            if (cliente == null)
            {
                retorno.OperacaoValida = false;
                retorno.Mensagens.Add("Cliente não encontrado");
            }

            retorno = _clienteService.Excluir(id);

            return retorno;
        }
    }
}
