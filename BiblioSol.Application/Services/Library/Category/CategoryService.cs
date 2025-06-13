

using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Application.Extentions.Library.Category;
using BiblioSol.Application.Interfaces.Respositories.Library;
using BiblioSol.Application.Interfaces.Services.Library;
using BiblioSol.Domain.Entities;
using BiblioSol.Domin.Base;

namespace BiblioSol.Application.Services.Library.Category
{
    public class CategoryService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoryService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<OperationResult> AddCategoriaAsync(CategoriaAddDto categoria)
        {
            Categoria categoriaEntity = new Categoria
            {

                descripcion = categoria.descripcion,
                fechaCreacion = categoria.fechaCreacion,
                usuarioCrecaion = categoria.usuarioCreacionId



            };
 
            await _categoriaRepository.AddAsync(categoriaEntity);
            throw new NotImplementedException("Implementar la lógica de retorno de resultado de operación aquí.");
        }


        public Task<OperationResult> DeleteCategoriaAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAllCategoriaAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetCategoriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> UpdateCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
