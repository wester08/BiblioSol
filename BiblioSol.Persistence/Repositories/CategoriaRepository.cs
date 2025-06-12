
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domin.Base;
using BiblioSol.Persistence.Base;
using BiblioSol.Persistence.Context;

namespace BiblioSol.Persistence.Repositories
{
    public sealed class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(BiblioContext context) : base(context)
        {
        }
        public override Task<OperationResult> AddAsync(Categoria entity)
        {
            return base.AddAsync(entity);
        }
    }
}
