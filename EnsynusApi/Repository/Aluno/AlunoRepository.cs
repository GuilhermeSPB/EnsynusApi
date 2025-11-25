using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Repository.Aluno;
using EnsynusApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using EnsynusApi.Dtos.Aluno;

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

        public async Task<Models.Aluno> GetByIdAsync(int id)
        {

            if(checarExistencia(id) == true){
                return await _context.Alunos.FindAsync(id);
            }
            return null;
            
        }

        public async Task<Models.Aluno> UpdateAsync(int id, UpdateAlunoDto alunoDto)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);

            if( alunoExistente == null)
            {
                return null;
            }
            alunoExistente.AluNome = alunoDto.AluNome;
            alunoDto.AluEmail = alunoDto.AluEmail;
            alunoDto.AluSenha = alunoDto.AluSenha;
            alunoExistente.AluDataNasc = alunoDto.AluDataNasc;
            alunoExistente.AluNomeResp = alunoDto.AluNomeResp;
            await _context.SaveChangesAsync();
            return alunoExistente;

        }

        public async Task<Models.Aluno> CreateAsync(Models.Aluno alunoModel)
        {
            await _context.Alunos.AddAsync(alunoModel);
            await _context.SaveChangesAsync();
            return alunoModel;
        }

        public async Task<Models.Aluno> DeleteAsync(int id)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);

            if( alunoExistente == null)
            {
                return null;
            }

            _context.Alunos.Remove(alunoExistente);
            await _context.SaveChangesAsync();
            return alunoExistente;
        }

        public async Task<Models.Aluno> RedefinirSenhaAsync(int id, RedefinirAlunoDto redefinirDto)
        {
            var alunoExistente = await _context.Alunos.FindAsync(id);

            if (alunoExistente == null)
            {
                return null;
            }

            alunoExistente.AluSenha = redefinirDto.AluSenha;
            await _context.SaveChangesAsync();
            return alunoExistente;
        }

        public bool checarExistencia(int id)
        {
            if (_context.Alunos.Any(e => e.AluId == id))
            {
                return true;
            }
            return false;
        }

        
    }
}
