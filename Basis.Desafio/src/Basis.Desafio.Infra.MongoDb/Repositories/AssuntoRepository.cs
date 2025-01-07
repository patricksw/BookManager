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
    public class AssuntoRepository(IMongoContext context, IMapper mapper) : IAssuntoRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Assunto domain)
        {
            var dto = _mapper.Map<AssuntoCollection>(domain);
            dto.Id = Guid.NewGuid();
            dto.CodAs = await _context.CollectionAssunto.CountDocumentsAsync(x => true) + 1;
            await _context.CollectionAssunto.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Assunto> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionAssunto.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Assunto>(dto);
        }

        public async Task<IEnumerable<Assunto>> ReadAll()
        {
            var dto = await _context.CollectionAssunto.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Assunto>(x));
        }

        public async Task<bool> Update(Guid id, Assunto domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionAssunto.Find(filter).FirstOrDefaultAsync();

            dto.Descricao = domain.Descricao;

            ReplaceOneResult updateResult = await _context.CollectionAssunto.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var filter = FindById(id);
            DeleteResult deleteResult = await _context.CollectionAssunto.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        private static FilterDefinition<AssuntoCollection> FindById(Guid id) => Builders<AssuntoCollection>.Filter.Eq(m => m.Id, id);
    }
}