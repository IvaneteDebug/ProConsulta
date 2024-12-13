using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
    public class CreateMedicoPage : ComponentBase
    {
        [Inject]
        private IMedicoRepository repository { get; set; } = null!;

        [Inject]
        private IEspecialidadeRepository especialidadeRepository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager? Navigation { get; set; } = null!;

        public List<Especialidade> Especialidades { get; set; } = new List<Especialidade>();
        public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is MedicoInputModel model)
                {
                    var medico = new Medico
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        CRM = model.CRM.SomenteCaracteres(),
                        EspecialidadeId = model.EspecialidadeId,
                        DataCastro = model.DataCastro
                    };

                    await repository.AddAsync(medico);
                    Snackbar.Add("Medico cadastrado com sucesso", Severity.Success);
                    Navigation!.NavigateTo("/medicos");
                };
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        protected override async Task OnInitializedAsync()
        {
            Especialidades = await especialidadeRepository.GetAllAsync();
        }
    }
}
