using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Services
{
    public interface IAssuntoService
    {
        Task<Guid> Add(Assunto assunto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Assunto>> GetAll();
        Task<Assunto> GetById(Guid id);
        Task<bool> Update(Guid id, Assunto assunto);
    }
}