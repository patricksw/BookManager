using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Services
{
    public interface ILivroService
    {
        Task<Guid> Add(Livro livro);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Livro>> GetAll();
        Task<Livro> GetById(Guid id);
        Task<bool> Update(Guid id, Livro livro);
    }
}