using EnsynusApi.Dtos.Aluno;
using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsynusApi.Repository.Aluno
{
    public interface IAlunoRepository
    {
        Task<List<Models.Aluno>> GetAllAsync();
        Task<Models.Aluno> GetByIdAsync(int id);
        Task<Models.Aluno> UpdateAsync(int id, UpdateAlunoDto alunoDto);
        Task<Models.Aluno> CreateAsync(Models.Aluno aluno);
        Task<Models.Aluno> DeleteAsync(int id);
    }
}
