using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Models;
using EnsynusApi.Repository.Turma;
using EnsynusApi.Dtos.Turma;
using EnsynusApi.Dtos.Aluno;

namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/turma")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaController(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }


        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var turmas = await _turmaRepository.GetAllAsync();
            var dto = turmas.Select(t => t.ToTurmaDto());
            return Ok(dto);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var turma = await _turmaRepository.GetByIdAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma.ToTurmaDto());
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateTurmaDto createDto)
        {
            var turmaDto = createDto.ToTurmaFromCreateDto();
            await _turmaRepository.CreateAsync(turmaDto);

            return Ok(turmaDto);
        }


        //[HttpPut]
        //[Route("edit/{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfessorDto dto)
        //{
        //    var professorModel = await _professorRepository.UpdateAsync(id, dto);

        //    if (professorModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(professorModel.ToProfessorDto());
        //}


        //[HttpDelete]
        //[Route("delete/{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var professorModel = await _professorRepository.DeleteAsync(id);

        //    if (professorModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(professorModel.ToProfessorDto());
        //}
    }
}
