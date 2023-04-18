using System.ComponentModel.DataAnnotations;
namespace AdopetAPI.Data.Dtos.Responsavel
{
    /// <summary>
    /// DTO de Criação do Responsavel
    /// </summary>
    public class CreateResponsavelDto
    {
        [Key, Required]
        public int Resp_Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do responsável!")]
        public string? Resp_Nome { get; set; }
        [Required(ErrorMessage = "É necessário informar o telefone do responsável!")]
        public string Resp_Telefone { get; set; }
        [Required(ErrorMessage = "Precisamos do emial para contato do responsável.")]
        public string Email { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
