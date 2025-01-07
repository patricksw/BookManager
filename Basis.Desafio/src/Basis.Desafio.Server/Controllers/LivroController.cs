using Basis.Desafio.Application.Livros.Requests;
using Basis.Desafio.Application.Livros.Responses;
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
    [Route("livro")]
    public class LivroController(ILogger<LivroController> logger, ILivroService service, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<LivroController> _logger = logger;
        private readonly ILivroService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpGet("")]
        public async Task<IEnumerable<LivroResponse>> GetAll()
        {
            var livros = await _service.GetAll();
            return _mapper.Map<IEnumerable<LivroResponse>>(livros);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(AddLivroRequest request)
        {
            try
            {
                return Ok(await _service.Add(_mapper.Map<Livro>(request)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao cadastrar livro.");
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<LivroResponse> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
            var livro = await _service.GetById(_id);
            return _mapper.Map<LivroResponse>(livro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, EditLivroRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                var livro = _mapper.Map<Livro>(request);
                await _service.Update(_id, livro);
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