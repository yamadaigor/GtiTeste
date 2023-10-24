using GtiTeste.Business.Base;
using GtiTeste.Business.Interfaces;
using GtiTeste.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GtiTeste.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EntidadeBase
    {
        protected readonly GtiDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(GtiDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Incluir(T entidade)
        {
            _dbSet.Add(entidade);
            SaveChanges();
        }
        public virtual void Atualizar(T entidade)
        {
            // Altera o estado o objeto no contexto para modificado pra poder alterar na base de dados.
            _context.Entry(entidade).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Excluir(Guid id)
        {
            // Altera o estado o objeto no contexto para excluído pra poder fazer a exclusão do registro.
            _context.Entry(_dbSet.Find(id)).State = EntityState.Deleted;
            SaveChanges();
        }

        public virtual T ObterPorId(Guid id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> ObterRegistros(Expression<Func<T, bool>> predicate)
        {
            // retorna os dados de acordo com a expressão eviada por parâmetro.
            return  _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public List<T> ObterTodosRegistros()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        // retorna a quantidade de registros "alterados" a base de dados.
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}
