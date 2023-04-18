using AdopetAPI.Data.Dtos.Pet;
using AdopetAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AdopetAPI.Controllers
{
    [ApiController, Route("api/v1/pets"), Tags("1. PETs")]
    public class PetController : ControllerBase
    {
        private readonly PetService _service;
        public PetController(PetService petService)
        {
            _service = petService;
        }
        /// <summary>
        /// Endpoint para adição de novos Pets.
        /// </summary>
        /// <param name="petDto"></param>
        /// <returns>teste</returns>
        [HttpPost]
        public IActionResult AdicionarPet([FromBody] CreatePetDto petDto)
        {
            ReadPetDto readDto = _service.AdicionarPet(petDto);
            return CreatedAtAction(nameof(RecuperarPetsPorId), new { Id = readDto.Pet_Id }, readDto);
        }
        /// <summary>
        /// Endpoint para retornar Pets pelo nome.
        /// </summary>
        /// <param name="nomeDoPet"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetornarPets([FromQuery] string nomeDoPet)
        {
            List<ReadPetDto> readDto = _service.RetornarPets(nomeDoPet);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para retornar Pets por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult RecuperarPetsPorId(int id)
        {
            ReadPetDto readDto = _service.RecuperarPetsPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para atualizar os dados do Pet.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="petDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarPet(int id, [FromBody] UpdatePetDto petDto)
        {
            Result resultado = _service.AtualizarPet(id, petDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Endpoint para deletar um Pet.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarPet(int id)
        {
            Result resultado = _service.DeletarPet(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
