using System.ComponentModel.DataAnnotations;

namespace AdopetAPI.Data.Dtos.Tutores
{
    /// <summary>
    /// DTO de Criação do Tutor
    /// </summary>
    public class CreateTutorDto
    {
        [Key]
        [Required]
        public int Tutor_Id { get; set; }
        [Required(ErrorMessage = "O nome do Tutor é um campo obrigatorio.")]
        public string? Tutor_Nome { get; set; }
        [Required(ErrorMessage = "Precisamos do telefone para contato do Tutor.")]
        public string Tutor_Telefone { get; set; }
        [Required(ErrorMessage = "Precisamos do email para contato do Tutor.")]
        public string Tutor_Email { get; set; }
        [Required(ErrorMessage = "Precisamos que seja informado a cidade!")]
        public string? Pet_Cidade { get; set; }
        [Required(ErrorMessage = "O UF(Estado) é um campo necessario!")]
        public string? Pet_UF { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
