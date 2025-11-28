using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Dtos.Turma;
using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Turma
{
    public static class TurmaDtoMapper
    {
        public static Models.Turma ToTurmaDto(this Models.Turma turmaModel)
        {

            return new Models.Turma
            {
                TurId = turmaModel.TurId,
                TurNome = turmaModel.TurNome,
                TurAreaConhecimento = turmaModel.TurAreaConhecimento,
                TurDescricao = turmaModel.TurDescricao,
                TurDuracao = turmaModel.TurDuracao,
                TurModalidade = turmaModel.TurModalidade
            };

        }

        public static Models.VwTurmaxprofessor ToTurmaDtoView(this Models.VwTurmaxprofessor turmaModelView)
        {
            return new Models.VwTurmaxprofessor
            {
                Cod = turmaModelView.Cod,
                Nome = turmaModelView.Nome,
                Area = turmaModelView.Area,
                Professor = turmaModelView.Professor,
                Modalidade = turmaModelView.Modalidade
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
