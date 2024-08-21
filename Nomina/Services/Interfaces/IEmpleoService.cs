using Nomina.Entities.DTOs;

namespace Nomina.Services.Interfaces
{
    public interface IEmpleoService
    {
        Task<List<EmpleoDTO>> GetAllAsync();
        Task<EmpleoDTO> GetByIdAsync(int id);
        Task<EmpleoDTO> CreateAsync(EmpleoDTO empleoDto);
        Task<EmpleoDTO> UpdateAsync(EmpleoDTO empleoDto);
        Task<bool> DeleteAsync(int id);
        Task GetByNameAsync(string nombre);
    }
}
