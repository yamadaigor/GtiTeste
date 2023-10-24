using GtiTeste.Business.Entidades;
using GtiTeste.Data.Mapeamento;
using System.Data.Entity;

namespace GtiTeste.Data.Data
{
    public class GtiDbContext : DbContext
    {
        public GtiDbContext() : base("ConexaoBancoDados") { }

        // DbSets
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configuração para que campos string não sejam criados como nvarchar e que, caso não tenha tamanho definido, 
            // tenha max length 100 por padrão
            modelBuilder.Properties<string>()
                .Configure(c => c
                 .HasColumnType("varchar")
                 .HasMaxLength(100));

            // Configura os mapeamentos da entidades com o EF
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EstadoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
