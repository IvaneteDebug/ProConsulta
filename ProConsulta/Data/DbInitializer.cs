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
                new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Especialidade médica que cuida do coração" },
                new Especialidade { Id = 2, Nome = "Dermatologia", Descricao = "Especialidade que trata de doenças e condições da pele." },
                new Especialidade { Id = 3, Nome = "Ortopedia", Descricao = "Especialidade focada no tratamento de ossos, músculos ." },
                new Especialidade { Id = 4, Nome = "Pediatria", Descricao = "Área médica voltada ao cuidado da saúde infantil." },
                new Especialidade { Id = 5, Nome = "Ginecologia", Descricao = "Especialidade que trata da saúde do sistema reprodutor feminino." },
                new Especialidade { Id = 6, Nome = "Neurologia", Descricao = "Área da medicina que trata do sistema nervoso." },
                new Especialidade { Id = 7, Nome = "Psiquiatria", Descricao = "Especialidade que cuida da saúde mental e transtornos psicológicos." },
                new Especialidade { Id = 8, Nome = "Oftalmologia", Descricao = "Especialidade dedicada ao cuidado da visão e dos olhos." },
                new Especialidade { Id = 9, Nome = "Endocrinologia", Descricao = "Especialidade que trata das glândulas e hormônios do corpo." },
                new Especialidade { Id = 10, Nome = "Gastroenterologia", Descricao = "Área médica que cuida do sistema digestivo." }
             );
        }
    }
}
