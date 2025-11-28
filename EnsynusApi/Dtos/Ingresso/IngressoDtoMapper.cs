using EnsynusApi.Dtos.Ingresso;
using EnsynusApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnsynusApi.Dtos.Ingresso
{
    public static class IngressoDtoMapper
    {
        public static Models.Ingresso ToIngressoToCreateDto(this CreateIngressoDto createDto)
        {
            return new Models.Ingresso
            {
                FkAluId = createDto.FkAluId,
                FkTurId = createDto.FkTurId,
                IngDataEntrada = createDto.IngDataEntrada,
                IngDataSaida = createDto.IngDataSaida,
                IngSolicitacao = createDto.IngSolicitacao,
            };
        }

        public static VwIngressoAlunoAprovadoDto ToIngressoVwAlunoAprovado(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoAlunoAprovadoDto
            {
                TurmaNome = vwIngresso.TurmaNome,
                DataEntrada = vwIngresso.DataEntrada
            };
        }

        public static VwIngressoAlunoSaiuDto ToIngressoVwAlunoSaiuDto(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoAlunoSaiuDto
            {
                TurmaNome = vwIngresso.TurmaNome,
                DataEntrada = vwIngresso.DataSaida,
                DataSaida = vwIngresso.DataSaida,
                Solicitacao = vwIngresso.Solicitacao
            };
        }

        public static VwIngressoAlunoSolicitacaoDto ToIngressoVwAlunoSolicitacaoDto(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoAlunoSolicitacaoDto
            {
                TurmaNome = vwIngresso.TurmaNome,
                Solicitacao = vwIngresso.Solicitacao
            };
        }

        public static VwIngressoProfessorAprovadoDto ToIngressoVwProfessorAprovadoDto(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoProfessorAprovadoDto
            {
                AlunoNome = vwIngresso.AlunoNome,
                DataEntrada = vwIngresso.DataEntrada
            };
        }

        public static VwIngressoProfessorPendenteDto ToIngressoVwProfessorPendenteDto(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoProfessorPendenteDto
            {
                AlunoNome = vwIngresso.AlunoNome
            };
        }

        public static VwIngressoProfessorXTurmasDto ToIngressoVwProfessorXTurmasDto(this Models.VwIngresso vwIngresso)
        {
            return new VwIngressoProfessorXTurmasDto
            {
                Cod = vwIngresso.Cod,
                TurmaNome = vwIngresso.TurmaNome
            };
        }
    }
}
