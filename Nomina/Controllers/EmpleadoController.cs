using Microsoft.AspNetCore.Mvc;
using Nomina.Entities;
using Nomina.Entities.DTOs;
using Nomina.Services.Interfaces;

namespace Nomina.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IEmpleoService _empleoService;

        public EmpleadoController(IEmpleadoService empleadoService, IEmpleoService empleoService)
        {
            _empleadoService = empleadoService;
            _empleoService = empleoService;
        }

        public async Task<IActionResult> Index()
        {
            var empleados = await _empleadoService.GetAllAsync();
            var empleos = await _empleoService.GetAllAsync();
            var empleoNombres = empleos.ToDictionary(e => e.Id, e => e.Nombre); // Crear un diccionario de ID de empleo a nombre de empleo
            ViewBag.Empleos = empleos; // Enviar lista de empleos a la vista
            ViewBag.EmpleoNombres = empleoNombres; // Enviar diccionario de ID de empleo a nombre de empleo a la vista
            return View(empleados);
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoDTO empleadoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _empleadoService.CreateAsync(empleadoDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            var empleados = await _empleadoService.GetAllAsync();
            var empleos = await _empleoService.GetAllAsync();
            ViewBag.Empleos = empleos; // Enviar lista de empleos a la vista si hay errores
            return View("Index", empleados); // Handle errors and redisplay form
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmpleadoDTO empleadoDto)
        {
            if (ModelState.IsValid)
            {
                await _empleadoService.UpdateAsync(empleadoDto);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index)); // Handle errors as needed
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _empleadoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, bool nuevoEstado)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            empleado.estado = nuevoEstado;
            await _empleadoService.UpdateAsync(empleado);

            return Json(new { success = true });
        }
    }
}
