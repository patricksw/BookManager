using System;

namespace Basis.Desafio.Application.Assuntos.Responses
{
    public record AssuntoResponse(Guid Id,
                                  int CodAs,
                                  string Descricao);
}