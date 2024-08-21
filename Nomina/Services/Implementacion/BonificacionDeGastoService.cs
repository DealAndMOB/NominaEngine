using Microsoft.EntityFrameworkCore;
using Nomina.Entities;
using Nomina.Entities.DTOs;
using Nomina.Models;
using Nomina.Services.Interfaces;

namespace Nomina.Services.Implementacion
{
    public class BonificacionDeGastoService : IBonificacionDeGastoService
    {
        private readonly Context _context;

        public BonificacionDeGastoService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BonificacionDeGastoDTO>> GetAllAsync()
        {
            return await _context.BonificacionDeGastos
                    .Include(b => b.Empleado) // Incluir la entidad Empleado
                    .Select(b => new BonificacionDeGastoDTO
                    {
                        Id = b.Id,
                        empleadoId = b.empleadoId,
                        fecha = b.fecha,
                        monto = b.monto,
                        concepto = b.concepto,
                        estado = b.estado
                    })
                    .ToListAsync();

        }
        public async Task<BonificacionDeGastoDTO> GetByIdAsync(int id)
        {
            var bonificacion = await _context.BonificacionDeGastos.FindAsync(id);
            if (bonificacion == null)
            {
                return null;
            }

            return new BonificacionDeGastoDTO
            {
                Id = bonificacion.Id,
                empleadoId = bonificacion.empleadoId,
                fecha = bonificacion.fecha,
                monto = bonificacion.monto,
                concepto = bonificacion.concepto,
                estado = bonificacion.estado
            };
        }
        public async Task<IEnumerable<BonificacionDeGastoDTO>> GetByEmpleadoIdAsync(int empleadoId)
        {
            return await _context.BonificacionDeGastos
                .Where(b => b.empleadoId == empleadoId)
                .Select(b => new BonificacionDeGastoDTO
                {
                    Id = b.Id,
                    empleadoId = b.empleadoId,
                    fecha = b.fecha,
                    monto = b.monto,
                    concepto = b.concepto,
                    estado = b.estado
                })
                .ToListAsync();
        }
        public async Task<BonificacionDeGastoDTO> CreateAsync(BonificacionDeGastoDTO bonificacionDeGastoDto)
        {
            var bonificacion = new BonificacionDeGasto
            {
                empleadoId = bonificacionDeGastoDto.empleadoId,
                fecha = bonificacionDeGastoDto.fecha,
                monto = bonificacionDeGastoDto.monto,
                concepto = bonificacionDeGastoDto.concepto,
                estado = bonificacionDeGastoDto.estado
            };

            _context.BonificacionDeGastos.Add(bonificacion);
            await _context.SaveChangesAsync();

            bonificacionDeGastoDto.Id = bonificacion.Id;
            return bonificacionDeGastoDto;
        }
        public async Task<BonificacionDeGastoDTO> UpdateAsync(BonificacionDeGastoDTO bonificacionDeGastoDto)
        {
            var bonificacion = await _context.BonificacionDeGastos.FindAsync(bonificacionDeGastoDto.Id);
            if (bonificacion == null)
            {
                return null;
            }

            bonificacion.empleadoId = bonificacionDeGastoDto.empleadoId;
            bonificacion.fecha = bonificacionDeGastoDto.fecha;
            bonificacion.monto = bonificacionDeGastoDto.monto;
            bonificacion.concepto = bonificacionDeGastoDto.concepto;
            bonificacion.estado = bonificacionDeGastoDto.estado;

            _context.BonificacionDeGastos.Update(bonificacion);
            await _context.SaveChangesAsync();

            return bonificacionDeGastoDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bonificacion = await _context.BonificacionDeGastos.FindAsync(id);
            if (bonificacion == null)
            {
                return false;
            }

            _context.BonificacionDeGastos.Remove(bonificacion);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
