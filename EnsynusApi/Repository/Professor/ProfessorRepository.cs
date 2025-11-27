using EnsynusApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;
using EnsynusApi.Dtos.Professor;

namespace EnsynusApi.Repository.Professor
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly EnsynusContext _context;

        public ProfessorRepository(EnsynusContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Professor>> GetAllAsync()
        {
            return await _context.Professors.ToListAsync();
        }

        public async Task<Models.Professor> GetByIdAsync(int id)
        {
            return await _context.Professors.FindAsync(id);
        }

        public async Task<Models.Professor> UpdateAsync(int id, UpdateProfessorDto dto)
        {
            var prof = await _context.Professors.FindAsync(id);

            if (prof == null)
            {
                return null;
            }

            prof.ProNome = dto.ProNome;
            prof.ProEmail = dto.ProEmail;
            prof.ProDataNasc = dto.ProDataNasc;

            await _context.SaveChangesAsync();
            return prof;
        }

        public async Task<Models.Professor> CreateAsync(Models.Professor professor)
        {
            await _context.Professors.AddAsync(professor);
            await _context.SaveChangesAsync();
            return professor;
        }

        public async Task<Models.Professor> DeleteAsync(int id)
        {
            var professorExistente = await _context.Professors.FindAsync(id);

            if (professorExistente == null)
            {
                return null;
            }

            _context.Professors.Remove(professorExistente);
            await _context.SaveChangesAsync();
            return professorExistente;
        }

        public async Task<Models.Professor> RedefinirSenhaAsync(int id, string senha)
        {
            var prof = await _context.Professors.FindAsync(id);

            if (prof == null)
            {
                return null;
            }

            prof.ProSenha = senha;
            await _context.SaveChangesAsync();
            return prof;
        }
    }
}
