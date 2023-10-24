
using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces;
using GtiTeste.Data.Data;
using System.Data.Entity;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GtiTeste.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GtiDbContext context) : base (context)
        {
        }
        public Cliente ObterClienteEndereco(Guid id)
        {
            return _context.Clientes.AsNoTracking().Include(c => c.Endereco).FirstOrDefault(c => c.Id == id);
        }

        public override IEnumerable<Cliente> ObterRegistros(Expression<Func<Cliente, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Include(c=> c.Endereco).Where(predicate).ToList();
        }
    }
}
