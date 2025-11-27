using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Dtos.Aluno;
using EnsynusApi.Dtos.Professor;
using EnsynusApi.Models;

namespace EnsynusApi.Dtos.Professor
{
    public static class ProfessorDtoMapper
    {
        public static ProfessorDto ToProfessorDto(this Models.Professor professorModel)
        {
            return new ProfessorDto
            {
                ProId = professorModel.ProId,
                ProNome = professorModel.ProNome,
                ProEmail = professorModel.ProEmail,
                ProSenha = professorModel.ProSenha,
                ProDataNasc = professorModel.ProDataNasc
            };
        }

        public static Models.Professor ToProfessorFromCreateDto(this CreateProfessorDto createProfessorDto)
        {
            return new Models.Professor
            {
                ProNome = createProfessorDto.ProNome,
                ProEmail = createProfessorDto.ProEmail,
                ProSenha = createProfessorDto.ProSenha,
                ProDataNasc = createProfessorDto.ProDataNasc
            };
        }

        public static Models.Professor ToProfessorFromRedefinirDto(this CreateProfessorDto createProfessorDto)
        {
            return new Models.Professor
            {
                ProSenha = createProfessorDto.ProSenha
            };
        }

    }

}

