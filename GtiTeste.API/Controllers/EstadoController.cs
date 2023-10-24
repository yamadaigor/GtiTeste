using AutoMapper;
using GtiTeste.API.Models;
using GtiTeste.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GtiTeste.API.Controllers
{
    public class EstadoController : ApiController
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMapper _mapper;
        public EstadoController(IEstadoRepository estadoRepository,
                                IMapper mapper)
        {
            _estadoRepository = estadoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("obter-todos-estados")]
        public IEnumerable<EstadoModel> ObterTodos()
        {
            return _mapper.Map<List<EstadoModel>>(_estadoRepository.ObterTodosRegistros().ToList());
        }
    }
}