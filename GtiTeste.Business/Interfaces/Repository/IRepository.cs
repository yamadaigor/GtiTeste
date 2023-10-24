using GtiTeste.Business.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GtiTeste.Business.Interfaces
{
    public interface IRepository<T> : IDisposable where T : EntidadeBase
    {
        void Incluir(T entidade);
        void Atualizar(T entidade);
        void Excluir(Guid id);
        T ObterPorId(Guid id);
        List<T> ObterTodosRegistros();
        int SaveChanges();
        IEnumerable<T> ObterRegistros(Expression<Func<T, bool>> predicate);
    }
}
