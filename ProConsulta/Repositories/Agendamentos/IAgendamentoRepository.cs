using ProConsulta.Models;

namespace ProConsulta.Repositories.Agendamentos
{
    public interface IAgendamentoRepository
    {
        Task AddAsync(Agendamento agendamento);
        Task<List<Agendamento>> GetAllAsync();
        Task DeleteByIdAsync(int id);
        Task<Agendamento?> GetByIdAsync(int id);
    }
}
