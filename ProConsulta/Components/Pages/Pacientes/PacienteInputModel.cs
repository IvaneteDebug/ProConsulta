using System.ComponentModel.DataAnnotations;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class PacienteInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser fornecido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Documento deve ser fornecido")]
        public string Documento { get; set; } = null!;

        [Required(ErrorMessage = "Email deve ser fornecido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        [MaxLength(50, ErrorMessage = "{0} deve ter no máximo {1} caracteres")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Celular deve ser fornecido")]
        public string Celular { get; set; } = null!;

        [Required(ErrorMessage = "Data de nascimento deve ser fornecida")]
        public DateTime DataNascimento { get; set; } = DateTime.Today;
    }
}
