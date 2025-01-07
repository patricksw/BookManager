using Basis.Desafio.Infra.MongoDb.Bases;

namespace Basis.Desafio.Infra.MongoDb.Collections
{
    public class AutorCollection : BaseCollection
    {
        public long CodAu { get; set; }
        public string Nome { get; set; }
    }
}