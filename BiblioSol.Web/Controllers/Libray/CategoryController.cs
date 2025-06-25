using BiblioSol.Shared.Extensions;
using BiblioSol.Shared.Dtos.CategoryDtos;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class CategoryController : Controller
    {
        private readonly ICategoryHttpService _service;

        public CategoryController(ICategoryHttpService service)
        {
            _service = service;
        }

        // GET: /Category/GetAllCategoria
        public async Task<IActionResult> GetAllCategoria()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<CategoryDto>());
        }


        public ActionResult FormSearchByIdCategory()
        {
            return View();
        }

        // GET: /Category/GetCategoriaById?id=1
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new CategoryDto());
        }

        // GET: /Category/Create
        public IActionResult AddCategoria()
        {
            return View();
        }

        // POST: /Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategoria(AddCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllCategoria));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        // GET: /Category/Edit/5
        public async Task<IActionResult> UpdateCategoriaById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = result.Data.ToUpdateDto();
                return View(updateDto);

            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllCategoria));
        }

        // POST: /Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategoriaById(int id, UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idCategoria = id;

            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllCategoria));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }


    }
}
