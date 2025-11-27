using EnsynusApi.Models;
using EnsynusApi.Data;
using EnsynusApi.Dtos.Turma;
using Microsoft.EntityFrameworkCore;

namespace EnsynusApi.Repository.Turma
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly EnsynusContext _context;

        public TurmaRepository(EnsynusContext context)
        {
            _context = context;
        }

        public async Task<List<Models.VwTurmaxprofessor>> GetAllAsync()
        {
            return await _context.VwTurmaxprofessors.ToListAsync();
        }

        public async Task<Models.VwTurmaxprofessor> GetByIdAsync(int id)
        {
            if(checarExistencia(id) == true){
                return await _context.VwTurmaxprofessors.FindAsync(id);
            }
            return null;
        }

        public async Task<Models.Turma> CreateAsync(Models.Turma turma)
        {
            await _context.Turmas.AddAsync(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Models.Turma> UpdateAsync(int id, UpdateTurmaDto turmaDto)
        {
            var turmaExistente = await _context.Turmas.FindAsync(id);

            if (turmaExistente == null)
            {
                return null;
            }

            turmaExistente.TurNome = turmaDto.TurNome;
            turmaExistente.TurDescricao = turmaDto.TurDescricao;
            turmaExistente.TurAreaConhecimento = turmaDto.TurAreaConhecimento;
            turmaExistente.TurDuracao = turmaDto.TurDuracao;
            turmaExistente.TurModalidade = turmaDto.TurModalidade;
            turmaExistente.FkIdProfessor = turmaDto.FkIdProfessor.Value;

            await _context.SaveChangesAsync();
            return turmaExistente;
        }

        public bool checarExistencia(int id)
        {
            if (_context.Turmas.Any(e => e.TurId == id))
            {
                return true;
            }
            return false;
        }
    }
}
