using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces.Repository;
using GtiTeste.Data.Data;

namespace GtiTeste.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(GtiDbContext context) : base(context)
        {
        }
    }
}
