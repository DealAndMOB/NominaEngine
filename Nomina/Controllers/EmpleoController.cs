using Microsoft.AspNetCore.Mvc;
using Nomina.Entities.DTOs;
using Nomina.Services.Interfaces;

namespace Nomina.Controllers
{
    public class EmpleoController : Controller
    {
        private readonly IEmpleoService _empleoService;

        public EmpleoController(IEmpleoService empleoService)
        {
            _empleoService = empleoService;
        }

        public async Task<IActionResult> Index()
        {
            var empleos = await _empleoService.GetAllAsync();
            return View(empleos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpleoDTO empleoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _empleoService.CreateAsync(empleoDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Obtener todos los empleos para pasarlos a la vista Index
            var empleos = await _empleoService.GetAllAsync();
            return View("Index", empleos); // Regresa a la vista Index en caso de error
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmpleoDTO empleoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _empleoService.UpdateAsync(empleoDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Obtener todos los empleos para pasarlos a la vista Index
            var empleos = await _empleoService.GetAllAsync();
            return View("Index", empleos);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _empleoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, bool nuevoEstado)
        {
            var empleo = await _empleoService.GetByIdAsync(id);
            if (empleo == null)
            {
                return NotFound();
            }

            empleo.estado = nuevoEstado;
            await _empleoService.UpdateAsync(empleo);

            return Json(new { success = true });
        }
    }
}


