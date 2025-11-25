using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnsynusApi.Dtos.Aluno;
using EnsynusApi.Data;
using EnsynusApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnsynusApi.Repository.Aluno;


namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly EnsynusContext _context;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(EnsynusContext context, IAlunoRepository alunoRepository)
        {
            _context = context;
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAtivos()
        {
            var alunos = await _alunoRepository.GetAllAsync();
            var alunosDto = alunos.Select(a => a.ToAlunoDto());
            return Ok(alunosDto);
        }
    }
}
