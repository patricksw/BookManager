using System;

namespace Basis.Desafio.Domain
{
    public class Assunto
    {
        public Guid Id { get; init; }
        public long CodAs { get; init; }
        public string Descricao { get; init; }
    }
}