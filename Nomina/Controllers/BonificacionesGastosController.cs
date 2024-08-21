using Microsoft.AspNetCore.Mvc;
using Nomina.Entities;
using Nomina.Entities.DTOs;
using Nomina.Services.Interfaces;

namespace Nomina.Controllers
{
    public class BonificacionesGastosController : Controller
    {
        private readonly IBonificacionDeGastoService _bonificacionDeGastoService;
        private readonly IEmpleadoService _empleadoService;

        public BonificacionesGastosController(IBonificacionDeGastoService bonificacionDeGastoService, IEmpleadoService empleadoService)
        {
            _bonificacionDeGastoService = bonificacionDeGastoService;
            _empleadoService = empleadoService;
        }

        public async Task<IActionResult> Index()
        {
            var bonificaciones = await _bonificacionDeGastoService.GetAllAsync();
            var empleados = await _empleadoService.GetAllAsync();
            var empleadoNombres = empleados.ToDictionary(e => e.Id, e => e.nombre);

            ViewBag.Empleados = empleadoNombres; // Asignar el diccionario de ID de empleado a nombre de empleado a la vista

            return View(bonificaciones);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePartial()
        {
            return PartialView("_CreatePartial");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartial(BonificacionDeGastoDTO bonificacionDeGastoDto)
        {
            if (ModelState.IsValid)
            {
                await _bonificacionDeGastoService.CreateAsync(bonificacionDeGastoDto);
                return RedirectToAction(nameof(Index));
            }

            var bonificaciones = await _bonificacionDeGastoService.GetAllAsync();
            var empleados = await _empleadoService.GetAllAsync();
            var empleadoNombres = empleados.ToDictionary(e => e.Id, e => e.nombre);
            ViewBag.Empleados = empleadoNombres; // Enviar diccionario de ID de empleado a nombre de empleado a la vista
            return PartialView("_CreatePartial", bonificacionDeGastoDto);
             
        }

        [HttpGet]
        public async Task<IActionResult> EditPartial(int id)
        {
            var bonificacion = await _bonificacionDeGastoService.GetByIdAsync(id);
            if (bonificacion == null)
            {
                return NotFound();
            }
            return PartialView("_EditPartial", bonificacion);
        }

        [HttpPost]
        public async Task<IActionResult> EditPartial(BonificacionDeGastoDTO bonificacionDeGastoDto)
        {
            if (ModelState.IsValid)
            {
                await _bonificacionDeGastoService.UpdateAsync(bonificacionDeGastoDto);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_EditPartial", bonificacionDeGastoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _bonificacionDeGastoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
