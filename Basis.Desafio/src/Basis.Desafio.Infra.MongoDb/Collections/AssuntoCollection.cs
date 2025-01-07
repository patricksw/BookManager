using Basis.Desafio.Infra.MongoDb.Bases;

namespace Basis.Desafio.Infra.MongoDb.Collections
{
    public class AssuntoCollection : BaseCollection
    {
        public long CodAs { get; set; }
        public string Descricao { get; set; }
    }
}