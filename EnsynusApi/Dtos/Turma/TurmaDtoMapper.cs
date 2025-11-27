using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Dtos.Turma;
using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Aluno
{
    public static class TurmaDtoMapper
    {
        public static Models.VwTurmaxprofessor ToTurmaDto(this Models.VwTurmaxprofessor turmaModel)
        {
            return new Models.VwTurmaxprofessor
            {
                Cód = turmaModel.Cód,
                Nome = turmaModel.Nome,
                Área = turmaModel.Área,
                Professor = turmaModel.Professor,
                Modalidade = turmaModel.Modalidade
            };
        }

        public static Models.Turma ToTurmaFromCreateDto(this CreateTurmaDto createTurmaDto)
        {
            return new Models.Turma
            {
                TurNome = createTurmaDto.TurNome,
                TurAreaConhecimento = createTurmaDto.TurAreaConhecimento,
                TurDescricao = createTurmaDto.TurDescricao,
                TurDuracao = createTurmaDto.TurDuracao,
                TurModalidade = createTurmaDto.TurModalidade,
                FkIdProfessor = createTurmaDto.FkIdProfessor
            };
        }

    }
}
