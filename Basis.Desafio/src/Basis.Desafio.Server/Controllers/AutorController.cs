using Basis.Desafio.Application.Autores.Request;
using Basis.Desafio.Application.Autores.Responses;
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
    [Route("autor")]
    public class AutorController(ILogger<AutorController> logger, IAutorService service, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<AutorController> _logger = logger;
        private readonly IAutorService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("")]
        public async Task<IEnumerable<AutorResponse>> GetAll()
        {
            var livros = await _service.GetAll();
            return _mapper.Map<IEnumerable<AutorResponse>>(livros);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(AutorRequest request)
        {
            try
            {
                return Ok(await _service.Add(_mapper.Map<Autor>(request)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar autor.");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<AutorResponse> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
            var autor = await _service.GetById(_id);
            return _mapper.Map<AutorResponse>(autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, AutorRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                var autor = _mapper.Map<Autor>(request);
                await _service.Update(_id, autor);
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