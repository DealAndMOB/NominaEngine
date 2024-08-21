using Nomina.Entities.DTOs;

namespace Nomina.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> GetAllAsync();
        Task<EmpleadoDTO> GetByIdAsync(int id);
        Task<EmpleadoDTO> CreateAsync(EmpleadoDTO empleadoDto);
        Task<EmpleadoDTO> UpdateAsync(EmpleadoDTO empleadoDto);
        Task<bool> DeleteAsync(int id);
    }
}
