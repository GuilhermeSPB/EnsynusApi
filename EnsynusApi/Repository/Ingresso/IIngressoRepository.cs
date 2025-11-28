using EnsynusApi.Dtos.Ingresso;
using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsynusApi.Repository.Ingresso
{
    public interface IIngressoRepository
    {
        Task<List<Models.VwIngresso>> GetAllAlunosAsync(int id);
        Task<List<Models.VwIngresso>> GetAllTurmasAsync(int id);
        Task<Models.Ingresso> CreateAsync(Models.Ingresso ingresso);
        Task<Models.Ingresso> DeleteAsync(int id);
    }
}
