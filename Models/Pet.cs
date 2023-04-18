using AdopetAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace AdopetAPI.Models
{
    public class Pet
    {
        [Key]
        [Required]
        public int Pet_Id { get; set; }
        [Required(ErrorMessage = "O nome do pet é obrigatorio!")]
        public string? Pet_Nome { get; set; }
        [Required(ErrorMessage = "Pecisamos saber a idade do pet. O campo é obrigatorio!")]
        public int Pet_Idade { get; set; }
        [Required(ErrorMessage = "A especie do pet é importante! Precisa ser informado.")]
        public Especie Pet_Especie { get; set; }
        public string? Pet_Caracteristicas { get; set; }
        [Required(ErrorMessage = "Precisamos que seja informado a cidade!")]
        public string? Pet_Cidade { get; set; }
        [Required(ErrorMessage = "O UF(Estado) é um campo necessario!")]
        public string? Pet_UF { get; set; }
        [Required(ErrorMessage = "O Responsável não foi informado para vinculação ao pet.")]
        public virtual Responsavel? Pet_Responsavel { get; set; }
        public DateTime DtInsert { get; set; }

    }
}
