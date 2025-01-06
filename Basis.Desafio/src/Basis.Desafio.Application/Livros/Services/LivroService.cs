using Basis.Desafio.Domain;
using Basis.Desafio.Domain.Repositories;
using Basis.Desafio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Application.Livros.Services
{
    public class LivroService(ILivroRepository repository) : ILivroService
    {
        private readonly ILivroRepository _repository = repository;

        public async Task<Guid> Add(Livro livro)
        {
            return await _repository.Create(livro);
        }

        public async Task<IEnumerable<Livro>> GetAll()
        {
            return await _repository.ReadAll();
        }
    }
}