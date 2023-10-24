using GtiTeste.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtiTeste.Data.Mapeamento
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");

            HasKey(e => e.Id);

            Property(c => c.Sigla)
            .IsRequired()
            .HasMaxLength(2);

            Property(c => c.Descricao)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
