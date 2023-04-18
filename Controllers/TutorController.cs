using AdopetAPI.Data.Dtos.Responsavel;
using AdopetAPI.Data.Dtos.Tutores;
using AdopetAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AdopetAPI.Controllers
{
    [ApiController, Route("api/v1/tutores"), Tags("3. Tutores")]
    public class TutorController : ControllerBase
    {
        private readonly TutorService _service;
        public TutorController(TutorService tutorService)
        {
            _service = tutorService;
        }
        /// <summary>
        /// Endpoint para adicionar um Tutor
        /// </summary>
        /// <param name="tutorDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateTutorDto), StatusCodes.Status202Accepted)]
        public IActionResult AdicionarTutor([FromBody] CreateTutorDto tutorDto)
        {
            ReadTutorDto readDto = _service.AdicionarTutor(tutorDto);
            return CreatedAtAction(nameof(RecuperarTutorPorId), new { Id = readDto.Tutor_Id }, readDto);
        }
        /// <summary>
        /// Endpoint para retornar os tutores pelo nome.
        /// </summary>
        /// <param name="nomeDoTutor"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CreateTutorDto), StatusCodes.Status202Accepted)]
        public IActionResult RetornarTutores([FromQuery] string nomeDoTutor)
        {
            List<ReadTutorDto> readDto = _service.RetornarTutor(nomeDoTutor);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para retornar um tutor pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReadTutorDto), StatusCodes.Status202Accepted)]
        public IActionResult RecuperarTutorPorId(int id)
        {
            ReadTutorDto readDto = _service.RecuperarTutorPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para atualizar os dados do tutor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tutorDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateTutorDto), StatusCodes.Status202Accepted)]
        public IActionResult AtualizarTutor(int id, [FromBody] UpdateTutorDto tutorDto)
        {
            Result resultado = _service.AtualizarTutor(id, tutorDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Endpoint para deletar um tutor pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarTutor(int id)
        {
            Result resultado = _service.DeletarTutor(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
