using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Services
{
    public interface IAutorService
    {
        Task<Guid> Add(Autor autor);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Autor>> GetAll();
        Task<Autor> GetById(Guid id);
        Task<bool> Update(Guid id, Autor autor);
    }
}