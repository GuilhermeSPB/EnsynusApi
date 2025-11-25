using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;

namespace EnsynusApi.Repository.Aluno
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly EnsynusContext _context;


        public AlunoRepository(EnsynusContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Aluno>> GetAllAsync()
        {
            return await _context.Alunos.ToListAsync();
        }
    }
}
