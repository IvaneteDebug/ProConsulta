using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).
                IsRequired(true)
                .HasColumnType("Varchar(50)");

            builder.Property(x => x.Documento).
               IsRequired(true)
               .HasColumnType("NVarchar(11)");

            builder.Property(x => x.CRM).
               IsRequired(true)
               .HasColumnType("NVarchar(8)");

            builder.Property(x => x.Celular).
               IsRequired(true)
               .HasColumnType("NVarchar(11)");

            builder.Property(x => x.EspecialidadeId).
               IsRequired(true);

            builder.HasIndex(x => x.Documento).IsUnique();

            builder.HasMany(a => a.Agendamentos)
                .WithOne(m => m.Medico)
                .HasForeignKey(a => a.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
