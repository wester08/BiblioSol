using BiblioSol.Shared.Dtos;
using BiblioSol.Shared.Dtos.PrestamosDtos;
using BiblioSol.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiblioSol.Web.Controllers.Libray
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoHttpService _service;

        public PrestamoController(IPrestamoHttpService service)
        {
            _service = service;
        }

        // GET: /Prestamo/GetAllPrestamos
        public async Task<IActionResult> GetAllPrestamos()
        {
            var result = await _service.GetAllAsync();
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new List<PrestamoDto>());
        }

        // Vista para buscar por ID manualmente (opcional)
        public IActionResult FormSearchByIdPrestamo()
        {
            return View();
        }

        // GET: /Prestamo/GetPrestamoById?id=1
        public async Task<IActionResult> GetPrestamoById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                return View(result.Data);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(new PrestamoDto());
        }

        // GET: /Prestamo/AddPrestamo
        public IActionResult AddPrestamo()
        {
            return View();
        }

        // POST: /Prestamo/AddPrestamo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrestamo(PrestamoAddDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var result = await _service.AddAsync(dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllPrestamos));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }

        // GET: /Prestamo/UpdatePrestamoById/5
        public async Task<IActionResult> UpdatePrestamoById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.isSuccess)
            {
                var updateDto = new PrestamoUpdateDto
                {
                    idPrestamo = result.Data.idPrestamo,
                    fechaDevolucion = result.Data.fechaDevolucion,
                    //Terminar de mapear los demás campos necesarios
                };

                return View(updateDto);
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return RedirectToAction(nameof(GetAllPrestamos));
        }

        // POST: /Prestamo/UpdatePrestamoById/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePrestamoById(int id, PrestamoUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            dto.idPrestamo = id;

            var result = await _service.UpdateAsync(id, dto);
            if (result.isSuccess)
            {
                return RedirectToAction(nameof(GetAllPrestamos));
            }

            ModelState.AddModelError(string.Empty, result.Message);
            return View(dto);
        }
    }
}
