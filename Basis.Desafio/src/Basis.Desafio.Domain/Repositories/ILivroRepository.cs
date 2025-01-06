using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Repositories
{
    public interface ILivroRepository
    {
        Task<Guid> Create(Livro domain);
        Task<bool> Delete(Guid id);
        Task<Livro> Read(Guid id);
        Task<IEnumerable<Livro>> ReadAll();
        Task<bool> Update(Guid id, Livro domain);
    }
}