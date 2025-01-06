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
    [Route("[controller]")]
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
    }
}
