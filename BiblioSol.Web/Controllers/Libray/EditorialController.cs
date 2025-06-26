using BiblioSol.Application.DTOs.Library.Editorial;
using BiblioSol.Shared.Dtos.EditorialDtos;
using BiblioSol.Shared.Extensions;
using BiblioSol.Shared.Extensions.Library;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class EditorialController : Controller
    {
        private readonly IEditorialHttpService _service;

        public EditorialController(IEditorialHttpService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetAllEditoriales()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<EditorialDto>());
        }

        public IActionResult FormSearchByIdEditorial()
        {
            return View();
        }

        public async Task<IActionResult> GetEditorialById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new EditorialDto());
        }

        public IActionResult AddEditorial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditorial(EditorialAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
                return RedirectToAction(nameof(GetAllEditoriales));

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        public async Task<IActionResult> UpdateEditorial(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = result.Data.ToUpdateEditorialDto();
                return View(updateDto);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllEditoriales));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEditorial(int id, EditorialUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idEditorial = id;

            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
                return RedirectToAction(nameof(GetAllEditoriales));

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }
    }
}
