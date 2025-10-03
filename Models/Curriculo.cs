using System.ComponentModel.DataAnnotations;

namespace EmpregaAPI.Models
{
    public class Curriculo
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? NivelEducacional { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereço { get; set; }
        public string? Empresa { get; set; }
        public string? Cargo { get; set; }
        public string? PeriodoCargo { get; set; }
        public string? DescricaoAtividade { get; set; }
        public string? Instituto { get; set; }
        public string? Curso { get; set; }
        public string? PeriodoInstituto { get; set; }
        public string? Certificacao { get; set; }
        public string? InstituicaoCertificacao { get; set; }
        public string? PeriodoCertificacao { get; set; }

        public bool? Excluido { get; set; }
    }
}
