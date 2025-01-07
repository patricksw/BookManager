using Basis.Desafio.Application.Assuntos.Request;
using Basis.Desafio.Application.Assuntos.Responses;
using Basis.Desafio.Domain;
using Basis.Desafio.Domain.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Server.Controllers
{
    [ApiController]
    [Route("assunto")]
    public class AssuntoController(ILogger<AssuntoController> logger, IAssuntoService service, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<AssuntoController> _logger = logger;
        private readonly IAssuntoService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("")]
        public async Task<IEnumerable<AssuntoResponse>> GetAll()
        {
            var livros = await _service.GetAll();
            return _mapper.Map<IEnumerable<AssuntoResponse>>(livros);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(AssuntoRequest request)
        {
            try
            {
                return Ok(await _service.Add(_mapper.Map<Assunto>(request)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar assunto.");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<AssuntoResponse> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
            var assunto = await _service.GetById(_id);
            return _mapper.Map<AssuntoResponse>(assunto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, AssuntoRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                var assunto = _mapper.Map<Assunto>(request);
                await _service.Update(_id, assunto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar.");
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                await _service.Delete(_id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir.");
                return BadRequest();
            }
        }
    }
}