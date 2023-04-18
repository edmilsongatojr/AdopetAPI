using AdopetAPI.Data.Dtos.Responsavel;
using AdopetAPI.Data.Dtos.Tutores;
using AdopetAPI.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AdopetAPI.Controllers
{
    [ApiController, Route("api/v1/responsaveis"), Tags("2. Responsaveis dos Pets")]
    public class ResponsavelController : ControllerBase
    {
        private readonly ResponsavelService _service;
        public ResponsavelController(ResponsavelService responsavelService)
        {
            _service = responsavelService;
        }
        /// <summary>
        /// Endpoint para adicionar um novo Reponsavel do Pet.
        /// </summary>
        /// <param name="responsavelDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarResponsavel([FromBody] CreateResponsavelDto responsavelDto)
        {
            ReadResponsavelDto readDto = _service.AdicionarResponsavel(responsavelDto);
            return CreatedAtAction(nameof(RecuperarResponsavelsPorId), new { Id = readDto.Resp_Id }, readDto);
        }
        /// <summary>
        /// Endpoint para Endpoint para retornar os reponsaveis pelo nome.
        /// </summary>
        /// <param name="nomeDoResponsavel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RetornarResponsavels([FromQuery] string nomeDoResponsavel)
        {
            List<ReadResponsavelDto> readDto = _service.RetornarResponsavels(nomeDoResponsavel);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para para retornar um reponsavel pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult RecuperarResponsavelsPorId(int id)
        {
            ReadResponsavelDto readDto = _service.RecuperarResponsavelsPorId(id);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }
        /// <summary>
        /// Endpoint para atualizar um responsavel.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="responsavelDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarResponsavel(int id, [FromBody] UpdateResponsavelDto responsavelDto)
        {
            Result resultado = _service.AtualizarResponsavel(id, responsavelDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
        /// <summary>
        /// Endpoint para deletar um responsavel.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarResponsavel(int id)
        {
            Result resultado = _service.DeletarResponsavel(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
