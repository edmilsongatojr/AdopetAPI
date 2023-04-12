namespace AdopetAPI.Models
{
    public class Pet
    {
        public int Pet_Id { get; set; }
        public string? Pet_Nome { get; set; }
        public int Pet_Idade { get; set; }
        public string? Pet_Cidade { get; set; }
        public string? Pet_UF { get; set; }
        public Responsavel? Pet_Responsavel { get; set; }
    }
}
