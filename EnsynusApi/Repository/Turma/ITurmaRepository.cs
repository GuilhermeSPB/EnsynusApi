using EnsynusApi.Dtos.Turma;
using EnsynusApi.Models;
using System.Threading.Tasks;

namespace EnsynusApi.Repository.Turma
{
    public interface ITurmaRepository
    {
        Task<List<Models.VwTurmaxprofessor>> GetAllAsync();
        Task<Models.VwTurmaxprofessor> GetByIdAsync(int id);
        Task<Models.Turma> CreateAsync(Models.Turma turma);
        Task<Models.Turma> UpdateAsync(int id, UpdateTurmaDto turmaDto);
        Task<Models.Turma> DeleteAsync(int id);
    }
}
