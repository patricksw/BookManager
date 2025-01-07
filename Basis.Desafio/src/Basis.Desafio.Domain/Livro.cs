using System;

namespace Basis.Desafio.Domain
{
    public class Livro
    {
        public Guid Id { get; init; }
        public int CodI { get; init; }
        public string Titulo { get; init; }
        public string Editora { get; init; }
        public int Edicao { get; init; }
        public string AnoPublicacao { get; init; }
    }
}