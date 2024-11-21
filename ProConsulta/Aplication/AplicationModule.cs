using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Aplication
{
    public static class AplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

            return services;
        }
    }
}
