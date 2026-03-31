using System.ComponentModel.DataAnnotations;

namespace academico.Models
{
    public class Projeto
    {
        [Key]
        public int ProjetoId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "A sigla não pode conter espaços.")]
        public string Sigla { get; set; } = string.Empty;

        [Required]
        public int Ano { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
