using Basis.Desafio.Domain;
using Basis.Desafio.Domain.Repositories;
using Basis.Desafio.Infra.MongoDb.Collections;
using Basis.Desafio.Infra.MongoDb.Context;
using MapsterMapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basis.Desafio.Infra.MongoDb.Repositories
{
    public class AutorRepository(IMongoContext context, IMapper mapper) : IAutorRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Autor domain)
        {
            var dto = _mapper.Map<AutorCollection>(domain);
            dto.Id = Guid.NewGuid();
            dto.CodAu = await _context.CollectionAutor.CountDocumentsAsync(x => true) + 1;
            await _context.CollectionAutor.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Autor> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionAutor.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Autor>(dto);
        }

        public async Task<IEnumerable<Autor>> ReadAll()
        {
            var dto = await _context.CollectionAutor.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Autor>(x));
        }

        public async Task<bool> Update(Guid id, Autor domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionAutor.Find(filter).FirstOrDefaultAsync();

            dto.Nome = domain.Nome;

            ReplaceOneResult updateResult = await _context.CollectionAutor.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var filter = FindById(id);
            DeleteResult deleteResult = await _context.CollectionAutor.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        private static FilterDefinition<AutorCollection> FindById(Guid id) => Builders<AutorCollection>.Filter.Eq(m => m.Id, id);

    }
}