using GtiTeste.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GtiTeste.Business.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterClienteEndereco(Guid id);
    }
}
