using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Repositories
{
    public interface IAutorRepository
    {
        Task<Guid> Create(Autor domain);
        Task<bool> Delete(Guid id);
        Task<Autor> Read(Guid id);
        Task<IEnumerable<Autor>> ReadAll();
        Task<bool> Update(Guid id, Autor domain);
    }
}