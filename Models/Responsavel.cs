using System.ComponentModel.DataAnnotations;

namespace AdopetAPI.Models
{
    public class Responsavel
    {
        [Key]
        [Required]
        public int Resp_Id { get; set; }
        [Required(ErrorMessage = "O nome do responável é um campo obrigatorio.")]
        public string? Resp_Nome { get; set; }
        [Required(ErrorMessage = "Precisamos do telefone para contato do responsável.")]
        public string Resp_Telefone { get; set; }
        [Required(ErrorMessage = "Precisamos do emial para contato do responsável.")]
        public string Email { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
