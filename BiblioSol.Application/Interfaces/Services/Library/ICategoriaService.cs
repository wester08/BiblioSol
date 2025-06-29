﻿using BiblioSol.Application.DTOs.Library.Category;
using BiblioSol.Domain.Base;

namespace BiblioSol.Application.Interfaces.Services.Library
{
    public interface ICategoriaService
    {
        Task<OperationResult> GetAllCategoriaAsync();
        Task<OperationResult> GetCategoriaByIdAsync(int id);
        Task<OperationResult> AddCategoriaAsync(CategoriaAddDto categoriaAdd);
        Task<OperationResult> UpdateCategoriaAsync(CategoriaUpdateDto categoriaUpdate);


    }
}
