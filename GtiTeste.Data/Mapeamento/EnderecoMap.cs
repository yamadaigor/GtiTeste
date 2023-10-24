using GtiTeste.Business.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace GtiTeste.Data.Mapeamento
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");

            HasKey(e => e.Id);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8);

            Property(c => c.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(c => c.Complemento)
                .HasMaxLength(100);

            Property(c => c.Bairro)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.Cidade)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.UF)
                .IsRequired()
                .HasMaxLength(2);
        }
    }
}
