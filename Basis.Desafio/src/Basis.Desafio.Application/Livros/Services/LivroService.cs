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

        public async Task<Livro> GetById(Guid id) => await _repository.Read(id);

        public async Task<bool> Update(Guid id, Livro livro)
        {
            return await _repository.Update(id, livro);
        }

        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}