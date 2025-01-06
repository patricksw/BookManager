using Basis.Desafio.Infra.MongoDb.Bases;

namespace Basis.Desafio.Infra.MongoDb.Collections
{
    public class LivroCollection : BaseCollection
    {
        public long CodI { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
    }
}