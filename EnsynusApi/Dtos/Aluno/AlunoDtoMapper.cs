using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Dtos.Aluno;
using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Aluno
{
    public static class AlunoDtoMapper
    {
        public static AlunoDto ToAlunoDto(this Models.Aluno alunoModel)
        {
            return new AlunoDto
            {
                AluId = alunoModel.AluId,
                AluNome = alunoModel.AluNome,
                AluEmail = alunoModel.AluEmail,
                AluDataNasc = alunoModel.AluDataNasc,
                AluEmailResp = alunoModel.AluEmailResp,
                AluNomeResp = alunoModel.AluNomeResp
            };
        }
    }
}
