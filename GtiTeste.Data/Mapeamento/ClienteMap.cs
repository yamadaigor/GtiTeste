using GtiTeste.Business.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace GtiTeste.Data.Mapeamento
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            HasKey(c => c.Id);

            // Deixa o campo CPF como único
            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnAnnotation("IX_CPF",new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(c => c.RG)
                .HasMaxLength(20);

            Property(c => c.DataExpedicao);

            Property(c => c.OrgaoExpedicao)
                .HasMaxLength(100);

            Property(c => c.UF)
                .HasMaxLength(2);

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Sexo)
               .IsRequired();

            Property(c => c.EstadoCivil)
               .IsRequired();

            // Relacionamento do EntityFramework
            HasRequired(c => c.Endereco)
                .WithRequiredPrincipal(e => e.Cliente);
        }
    }
}
