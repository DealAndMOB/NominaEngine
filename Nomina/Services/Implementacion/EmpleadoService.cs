using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Nomina.Entities.DTOs;
using Nomina.Entities;
using Nomina.Models;
using Nomina.Services.Interfaces;

namespace Nomina.Services.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly Context _context;

        public EmpleadoService(Context context)
        {
            _context = context;
        }
        public async Task<List<EmpleadoDTO>> GetAllAsync()
        {
            return await _context.Empleados
                                 .Include(e => e.Empleo) // Incluir la relación Empleo
                                 .Select(e => new EmpleadoDTO
                                 {
                                     Id = e.Id,
                                     empleoID = e.empleoID,
                                     nombre = e.nombre,
                                     estado = e.estado,
                                     salarioSem = e.salarioSem,
                                     diasLaborales = e.diasLaborales,
                                     curp = e.curp,
                                     fechaNacimiento = e.fechaNacimiento,
                                     fechaIngreso = e.fechaIngreso,
                                 })
                                 .ToListAsync();
        }

        public async Task<EmpleadoDTO> GetByIdAsync(int id)
        {
            var empleado = await _context.Empleados
                                         .Include(e => e.Empleo) // Incluir la relación Empleo
                                         .FirstOrDefaultAsync(e => e.Id == id);

            if (empleado == null) return null;

            return new EmpleadoDTO
            {
                Id = empleado.Id,
                empleoID = empleado.empleoID,
                nombre = empleado.nombre,
                estado = empleado.estado,
                salarioSem = empleado.salarioSem,
                diasLaborales = empleado.diasLaborales,
                curp = empleado.curp,
                fechaNacimiento = empleado.fechaNacimiento,
                fechaIngreso = empleado.fechaIngreso,
            };
        }

        public async Task<EmpleadoDTO> CreateAsync(EmpleadoDTO empleadoDto)
        {
            // Verifica si el nombre del empleo ya existe
            var empleadoExistente = await _context.Empleados
                                                .FirstOrDefaultAsync(e => e.curp.ToLower() == empleadoDto.curp.ToLower());

            if (empleadoExistente != null)
            {
                throw new InvalidOperationException("El empleado ya existe.");
            }

            var empleado = new Empleado
            {
                empleoID = empleadoDto.empleoID,
                nombre = empleadoDto.nombre,
                estado = empleadoDto.estado,
                salarioSem = empleadoDto.salarioSem,
                diasLaborales = empleadoDto.diasLaborales,
                curp = empleadoDto.curp,
                fechaNacimiento = empleadoDto.fechaNacimiento,
                fechaIngreso = empleadoDto.fechaIngreso,

            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            empleadoDto.Id = empleado.Id;
            return empleadoDto;
        }

        public async Task<EmpleadoDTO> UpdateAsync(EmpleadoDTO empleadoDto)
        {
            var empleado = await _context.Empleados
                                         .Include(e => e.Empleo) // Incluir la relación Empleo
                                         .FirstOrDefaultAsync(e => e.Id == empleadoDto.Id);

            if (empleado == null) return null;

            empleado.empleoID = empleadoDto.empleoID;
            empleado.nombre = empleadoDto.nombre;
            empleado.estado = empleadoDto.estado;
            empleado.salarioSem = empleadoDto.salarioSem;
            empleado.diasLaborales = empleadoDto.diasLaborales;
            empleado.curp = empleadoDto.curp;
            empleado.fechaNacimiento = empleadoDto.fechaNacimiento;
            empleado.fechaIngreso = empleadoDto.fechaIngreso;

            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();

            return empleadoDto;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return false;

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
