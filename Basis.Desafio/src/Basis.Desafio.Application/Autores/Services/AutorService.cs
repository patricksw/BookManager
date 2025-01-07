using Basis.Desafio.Domain;
using Basis.Desafio.Domain.Repositories;
using Basis.Desafio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Application.Assuntos.Services
{
    public class AutorService(IAutorRepository repository) : IAutorService
    {
        private readonly IAutorRepository _repository = repository;

        public async Task<Guid> Add(Autor autor)
        {
            return await _repository.Create(autor);
        }

        public async Task<IEnumerable<Autor>> GetAll()
        {
            return await _repository.ReadAll();
        }

        public async Task<Autor> GetById(Guid id) => await _repository.Read(id);

        public async Task<bool> Update(Guid id, Autor autor)
        {
            return await _repository.Update(id, autor);
        }

        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}