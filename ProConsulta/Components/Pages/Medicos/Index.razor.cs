using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using ProConsulta.Models;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
    public class IndexMedicoPage : ComponentBase
    {
        [Inject]
        public IMedicoRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager? Navigation { get; set; } = null!;
        public List<Medico> Medicos { get; set; } = new List<Medico>();
        public async Task DeleteMedicoAsync(Medico medico)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                  "Atenção",
                  $"Deseja excluir o médico {medico.Nome}?",
                  yesText: "SIM",
                  cancelText: "NÃO"
                );

                if (result is true)
                {
                    await repository.DeleteByIdAsync(medico.Id);

                    Snackbar.Add("Médico excluido com sucesso!", Severity.Success);

                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
        public bool HideButtons { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationState { get; set; }
        public void GoToUpdate(int id)
            => Navigation!.NavigateTo($"/medicos/update/{id}");

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationState!;

            HideButtons = !auth.User.IsInRole("Atendente");

            Medicos = await repository.GetAllAsync();
        }
    }
}
