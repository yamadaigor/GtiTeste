using GtiTeste.Business.Entidades;
using GtiTeste.Business.Interfaces;
using GtiTeste.Data.Data;

namespace GtiTeste.Data.Repository
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(GtiDbContext context) : base(context)
        {
        }
    }
}
