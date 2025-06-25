using BiblioSol.Shared.Dtos.LibrosDtos;
using BiblioSol.Shared.Extensions;
using BiblioSol.Shared.Extensions.Library;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class LibroController : Controller
    {
        private readonly ILibroHttpService _service;

        public LibroController(ILibroHttpService service)
        {
            _service = service;
        }

        // GET: /Libro/GetAllLibros
        public async Task<IActionResult> GetAllLibros()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<LibroDto>());
        }

        public ActionResult FormSearchByIdLibro()
        {
            return View();
        }

        // GET: /Libro/GetLibroById?id=1
        public async Task<IActionResult> GetLibroById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new LibroDto());
        }

        // GET: /Libro/AddLibro
        public IActionResult AddLibro()
        {
            return View();
        }

        // POST: /Libro/AddLibro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLibro(LibroAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllLibros));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        // GET: /Libro/UpdateLibroById/5
        public async Task<IActionResult> UpdateLibroById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = result.Data.ToUpdateLibroDto();
                return View(updateDto);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllLibros));
        }

        // POST: /Libro/UpdateLibroById/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLibroById(int id, LibroUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idLibro = id;
            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllLibros));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }
    }
}
