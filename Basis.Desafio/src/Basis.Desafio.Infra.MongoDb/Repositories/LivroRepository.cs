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
    public class LivroRepository(IMongoContext context, IMapper mapper) : ILivroRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Livro domain)
        {
            var dto = _mapper.Map<LivroCollection>(domain);
            dto.Id = Guid.NewGuid();
            dto.CodI = (await _context.CollectionLivro.Find(x => true)
                                                      .SortByDescending(x => x.CodI)
                                                      .Limit(1)
                                                      .FirstOrDefaultAsync()).CodI + 1;

            await _context.CollectionLivro.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Livro> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionLivro.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Livro>(dto);
        }

        public async Task<IEnumerable<Livro>> ReadAll()
        {
            var dto = await _context.CollectionLivro.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Livro>(x));
        }

        public async Task<bool> Update(Guid id, Livro domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionLivro.Find(filter).FirstOrDefaultAsync();

            dto.Titulo = domain.Titulo;
            dto.Editora = domain.Editora;
            dto.Edicao = domain.Edicao;
            dto.AnoPublicacao = domain.AnoPublicacao;

            ReplaceOneResult updateResult = await _context.CollectionLivro.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var filter = FindById(id);
            DeleteResult deleteResult = await _context.CollectionLivro.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        private static FilterDefinition<LivroCollection> FindById(Guid id) => Builders<LivroCollection>.Filter.Eq(m => m.Id, id);
    }
}