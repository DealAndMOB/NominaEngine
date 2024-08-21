using Nomina.Entities.DTOs;
using Nomina.Entities;
using Nomina.Models;
using Nomina.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Nomina.Services.Implementacion
{
    public class EmpleoService: IEmpleoService
    {
        private readonly Context _context;

        public EmpleoService(Context context)
        {
            _context = context;
        }
        public async Task<List<EmpleoDTO>> GetAllAsync()
        {
            return await _context.Empleos
                                 .Select(e => new EmpleoDTO
                                 {
                                     Id = e.Id,
                                     Nombre = e.nombre,
                                     estado = e.estado,
                                     Descripcion = e.descripcion
                                 })
                                 .ToListAsync();
        }
        public async Task<EmpleoDTO> GetByIdAsync(int id)
        {
            var empleo = await _context.Empleos.FindAsync(id);
            if (empleo == null) return null;

            return new EmpleoDTO
            {
                Id = empleo.Id,
                Nombre = empleo.nombre,
                estado = empleo.estado,
                Descripcion = empleo.descripcion
            };
        }
        public async Task<EmpleoDTO> CreateAsync(EmpleoDTO empleoDto)
        {
            // Verifica si el nombre del empleo ya existe
            var empleoExistente = await _context.Empleos
                                                .FirstOrDefaultAsync(e => e.nombre.ToLower() == empleoDto.Nombre.ToLower());

            if (empleoExistente != null)
            {
                throw new InvalidOperationException("El empleo ya existe.");

            }

            var empleo = new Empleo
            {
                nombre = empleoDto.Nombre,
                estado = empleoDto.estado,
                descripcion = empleoDto.Descripcion
            };

            _context.Empleos.Add(empleo);
            await _context.SaveChangesAsync();

            empleoDto.Id = empleo.Id;
            return empleoDto;
        }



        public async Task<EmpleoDTO> UpdateAsync(EmpleoDTO empleoDto)
        {
            var empleo = await _context.Empleos.FindAsync(empleoDto.Id);
            if (empleo == null) return null;

            empleo.nombre = empleoDto.Nombre;
            empleo.estado = empleoDto.estado;
            empleo.descripcion = empleoDto.Descripcion;

            _context.Empleos.Update(empleo);
            await _context.SaveChangesAsync();

            return empleoDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empleo = await _context.Empleos.FindAsync(id);
            if (empleo == null) return false;

            _context.Empleos.Remove(empleo);
            await _context.SaveChangesAsync();

            return true;
        }

        public Task GetByNameAsync(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
