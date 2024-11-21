using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        internal void seed()
        {
            _modelBuilder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Id = "04f1966f-0c94-4999-a602-d81ee9332fa7",
                    Name = "Atendente",
                    NormalizedName = "ATENDENTE"
                },
                new IdentityRole
                {
                    Id = "00011110-c371-499c-88bf-4faf4f57e9c9",
                    Name = "Medico",
                    NormalizedName = "MEDICO"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            _modelBuilder.Entity<Atendente>().HasData
             (
                 new Atendente
                 {
                     Id = "33f0ef9f-3d09-48ba-86d6-500a130e569c",
                     Nome = "Pro Consulta",
                     Email = "proconsulta@gmail.com",
                     EmailConfirmed = true,
                     UserName = "proconsulta@gmail.com.br",
                     NormalizedEmail = "PROCONSULTA@GMAIL.COM.BR",
                     NormalizedUserName = "PROCONSULTA@GMAIL.COM.BR",
                     PasswordHash = hasher.HashPassword(null, "Pa$$word")
                 }
             );

            _modelBuilder.Entity<IdentityUserRole<string>>().HasData
             (
                new IdentityUserRole<string>
                {
                    RoleId = "04f1966f-0c94-4999-a602-d81ee9332fa7",
                    UserId = "33f0ef9f-3d09-48ba-86d6-500a130e569c"
                }
             );

            _modelBuilder.Entity<Especialidade>().HasData
             (
                new Especialidade { Id = 1, Descricao = "Especialista médica que trata doenças do coração e do sistema vascular", Nome = "Neurologista" },
                new Especialidade { Id = 2, Descricao = "Especialista médica que trata doenças relacionadas ao cérebro e ao sistema nervoso", Nome = "Neurologista" },
                new Especialidade { Id = 3, Descricao = "Especialista médica que trata problemas de pele, cabelos e unhas", Nome = "Dermatologista" },
                new Especialidade { Id = 4, Descricao = "Especialista médica que diagnostica e trata problemas hormonais e do sistema endócrino", Nome = "Endocrinologista" },
                new Especialidade { Id = 5, Descricao = "Especialista médica que trata doenças relacionadas aos rins e ao sistema urinário", Nome = "Nefrologista" }
             );
        }
    }
}
