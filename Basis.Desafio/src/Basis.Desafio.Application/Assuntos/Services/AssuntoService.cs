using Basis.Desafio.Domain;
using Basis.Desafio.Domain.Repositories;
using Basis.Desafio.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Application.Assuntos.Services
{
    public class AssuntoService(IAssuntoRepository repository) : IAssuntoService
    {
        private readonly IAssuntoRepository _repository = repository;

        public async Task<Guid> Add(Assunto assunto)
        {
            return await _repository.Create(assunto);
        }

        public async Task<IEnumerable<Assunto>> GetAll()
        {
            return await _repository.ReadAll();
        }

        public async Task<Assunto> GetById(Guid id) => await _repository.Read(id);

        public async Task<bool> Update(Guid id, Assunto assunto)
        {
            return await _repository.Update(id, assunto);
        }

        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}