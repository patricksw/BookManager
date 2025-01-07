using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Repositories
{
    public interface IAssuntoRepository
    {
        Task<Guid> Create(Assunto domain);
        Task<bool> Delete(Guid id);
        Task<Assunto> Read(Guid id);
        Task<IEnumerable<Assunto>> ReadAll();
        Task<bool> Update(Guid id, Assunto domain);
    }
}