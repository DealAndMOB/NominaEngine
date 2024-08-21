using Nomina.Entities.DTOs;

namespace Nomina.Services.Interfaces
{
    public interface IBonificacionDeGastoService
    {
        Task<IEnumerable<BonificacionDeGastoDTO>> GetAllAsync();
        Task<BonificacionDeGastoDTO> GetByIdAsync(int id);
        Task<BonificacionDeGastoDTO> CreateAsync(BonificacionDeGastoDTO bonificacionDeGastoDto);
        Task<BonificacionDeGastoDTO> UpdateAsync(BonificacionDeGastoDTO bonificacionDeGastoDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<BonificacionDeGastoDTO>> GetByEmpleadoIdAsync(int empleadoId); // metodo para obtener todas las bonificaciones de un solo empleado
    }
}
