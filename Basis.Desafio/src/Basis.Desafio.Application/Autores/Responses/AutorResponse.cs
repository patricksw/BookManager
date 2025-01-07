using System;

namespace Basis.Desafio.Application.Autores.Responses
{
    public record AutorResponse(Guid Id,
                                int CodAu,
                                string Nome);
}