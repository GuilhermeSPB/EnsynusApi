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

        public static Models.Aluno ToAlunoFromCreateDto(this CreateAlunoDto createAlunoDto)
        {
            return new Models.Aluno
            {
                AluNome = createAlunoDto.AluNome,
                AluEmail = createAlunoDto.AluEmail,
                AluDataNasc = createAlunoDto.AluDataNasc,
                AluEmailResp = createAlunoDto.AluEmailResp,
                AluNomeResp = createAlunoDto.AluNomeResp,
                AluSenha = createAlunoDto.AluSenha
            };
        }

        public static Models.Aluno ToAlunoFromRedefinirDto(this CreateAlunoDto createAlunoDto)
        {
            return new Models.Aluno
            {
                AluSenha = createAlunoDto.AluSenha
            };
        }

    }
}
