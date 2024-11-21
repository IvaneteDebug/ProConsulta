using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidades");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).
                IsRequired(true)
                .HasColumnType("Varchar(60)");

            builder.Property(x => x.Descricao).
               IsRequired(false)
               .HasColumnType("Varchar(150)");

            builder.HasMany(m => m.Medicos)
                .WithOne(e => e.Especialidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
