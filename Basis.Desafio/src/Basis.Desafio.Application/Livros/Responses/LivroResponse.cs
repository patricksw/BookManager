using System;

namespace Basis.Desafio.Application.Livros.Responses
{
    public record LivroResponse(Guid Id, int CodI,
                                string Titulo,
                                string Editora,
                                int Edicao,
                                string AnoPublicacao);
}