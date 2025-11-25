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
    }
}
