using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Desafio.Domain.Services
{
    public interface ILivroService
    {
        Task<Guid> Add(Livro livro);
        Task<IEnumerable<Livro>> GetAll();
    }
}