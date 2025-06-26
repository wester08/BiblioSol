using BiblioSol.Shared.Dtos.AutorDtos;
using BiblioSol.Shared.Extensions;
using BiblioSol.Shared.Extensions.Library;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class AutorController : Controller
    {
        private readonly IAutorHttpService _service;

        public AutorController(IAutorHttpService service)
        {
            _service = service;
        }

        // GET: /Autor/GetAllAutores
        public async Task<IActionResult> GetAllAutores()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<AutorDto>());
        }

        public IActionResult FormSearchByIdAutor()
        {
            return View();
        }

        // GET: /Autor/GetAutorById?id=1
        public async Task<IActionResult> GetAutorById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new AutorDto());
        }

        // GET: /Autor/AddAutor
        public IActionResult AddAutor()
        {
            return View();
        }

        // POST: /Autor/AddAutor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAutor(AutorAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllAutores));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        // GET: /Autor/UpdateAutor?id=5
        public async Task<IActionResult> UpdateAutor(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = result.Data.ToUpdateAutorDto();
                return View(updateDto);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllAutores));
        }

        // POST: /Autor/UpdateAutorById?id=5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAutor(int id, AutorUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idAutor = id;

            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllAutores));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }
    }
}
