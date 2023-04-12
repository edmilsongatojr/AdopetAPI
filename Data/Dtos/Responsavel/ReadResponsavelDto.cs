using System.ComponentModel.DataAnnotations;

namespace AdopetAPI.Data.Dtos.Responsavel
{
    public class ReadResponsavelDto
    {
        [Key]
        [Required]
        public int Resp_Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do responsável!")]
        public string? Resp_Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar o telefone do responsável!")]
        public string? Resp_Telefone { get; set; }
    }
}
