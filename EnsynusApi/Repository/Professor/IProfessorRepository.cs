using EnsynusApi.Models;
using EnsynusApi.Dtos.Professor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnsynusApi.Repository.Professor
{
    public interface IProfessorRepository
    {
        Task<List<Models.Professor>> GetAllAsync();
        Task<Models.Professor> GetByIdAsync(int id);
        Task<Models.Professor> UpdateAsync(int id, UpdateProfessorDto professorDto);
        Task<Models.Professor> CreateAsync(Models.Professor professor);
        Task<Models.Professor> DeleteAsync(int id);
        Task<Models.Professor> RedefinirSenhaAsync(int id, string senha);
    }
}
