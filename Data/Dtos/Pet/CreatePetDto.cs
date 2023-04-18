using AdopetAPI.Data.Dtos.Responsavel;
using AdopetAPI.Data.Dtos.Tutores;
using AdopetAPI.Enum;
using System.ComponentModel.DataAnnotations;
namespace AdopetAPI.Data.Dtos.Pet
{
    /// <summary>
    /// DTO de Criação do PET
    /// </summary>
    public class CreatePetDto
    {
        [Required(ErrorMessage = "É necessário informar o nome do pet!")]
        public string? Pet_Nome { get; set; }
        [Required(ErrorMessage = "A idade do pet é importante! Precisa ser informado.")]
        public int Pet_Idade { get; set; }
        [Required(ErrorMessage = "A especie do pet é importante! Precisa ser informado.")]
        public Especie Pet_Especie { get; set; }
        public string? Pet_Caracteristicas { get; set; }
        [Required(ErrorMessage = "Não identificamos a Cidade do Pet, por favor informar!")]
        public string? Pet_Cidade { get; set; }
        [Required(ErrorMessage = "A UF(Estado) é necessário, tudo bem?")]
        public string? Pet_UF { get; set; }
        [Required(ErrorMessage = "O Responsavel do Pet é necessário ser informado.")]
        public CreateResponsavelDto? Responsavel { get; set; }
        public CreateTutorDto? Tutor { get; set; }
        public DateTime DtInsert { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
