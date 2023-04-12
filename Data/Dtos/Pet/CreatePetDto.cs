using System.ComponentModel.DataAnnotations;

namespace AdopetAPI.Data.Dtos.Pet
{
    /// <summary>
    /// DTO de Criação do PET
    /// </summary>
    public class CreatePetDto
    {
        [Key]
        [Required]
        public int Pet_Id { get; set; }
        [Required(ErrorMessage = "É necessário informar o nome do pet!")]
        public string? Pet_Nome { get; set; }
        [Required(ErrorMessage = "A idade do pet é importante! Precisa ser informado.")]
        public int Pet_Idade { get; set; }
        [Required(ErrorMessage = "Não identificamos a Cidade do Pet, por favor informar!")]
        public string? Pet_Cidade { get; set; }
        [Required(ErrorMessage = "A UF(Estado) é necessário, tudo bem?")]
        public string? Pet_UF { get; set; }
    }
}
    