﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using ProConsulta.Extensions;
using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class CreatePacientePage : ComponentBase
    {
        [Inject]
        public IPacienteRepository repository { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        public PacienteInputModel InputModel { get; set; } = new PacienteInputModel();

        public DateTime? DataNascimento { get; set; } = DateTime.Today;

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is PacienteInputModel model)
                {
                    var paciente = new Paciente
                    {
                        Nome = model.Nome,
                        Documento = model.Documento.SomenteCaracteres(),
                        Celular = model.Celular.SomenteCaracteres(),
                        Email = model.Email,
                        DataNascimento = model.DataNascimento
                    };

                    await repository.AddAsync(paciente);
                    Snackbar.Add("Paciente cadastrado com sucesso!", Severity.Success);
                    NavigationManager.NavigateTo("/pacientes");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
