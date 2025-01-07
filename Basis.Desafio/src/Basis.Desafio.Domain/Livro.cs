using System;

namespace Basis.Desafio.Domain
{
    public class Livro
    {
        public Guid Id { get; init; }
        public int CodI { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
    }
}