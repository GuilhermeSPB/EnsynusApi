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

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno.ToAlunoDto());
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateAlunoDto createDto)
        {
            var alunoModel = createDto.ToAlunoFromCreateDto();
            await _alunoRepository.CreateAsync(alunoModel);
            return CreatedAtAction(nameof(GetById), new { id = alunoModel.AluId }, alunoModel.ToAlunoDto());
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAlunoDto updateDto)
        {
            var alunoModel = await _alunoRepository.UpdateAsync(id, updateDto);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return Ok(alunoModel.ToAlunoDto());
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var alunoModel = await _alunoRepository.DeleteAsync(id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            return Ok(alunoModel.ToAlunoDto());
        }

        [HttpPut]
        [Route("redefinir-senha/{id}")]
        public async Task<IActionResult> RedefinirSenha([FromRoute] int id , [FromBody] CreateAlunoDto redefinirDtop)
        {
            var alunoModel = await _context.Alunos.FindAsync(id);
            if (alunoModel == null)
            {
                return NotFound();
            }

            alunoModel.AluSenha = redefinirDtop.AluSenha;
            await _context.SaveChangesAsync();

            return Ok(alunoModel.ToAlunoDto());
        }
    }
}
