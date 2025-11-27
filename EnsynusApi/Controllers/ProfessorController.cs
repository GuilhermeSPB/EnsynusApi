using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Models;
using EnsynusApi.Repository.Professor;
using EnsynusApi.Dtos.Professor;

namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/professor")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var professores = await _professorRepository.GetAllAsync();
            var dto = professores.Select(p => p.ToProfessorDto());
            return Ok(dto);
        }

        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var professor = await _professorRepository.GetByIdAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor.ToProfessorDto());
        }

        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateProfessorDto dto)
        {
            var professorModel = dto.ToProfessorFromCreateDto();
            await _professorRepository.CreateAsync(professorModel);

            return CreatedAtAction(nameof(GetById), new { id = professorModel.ProId }, professorModel.ToProfessorDto());
        }

        
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfessorDto dto)
        {
            var professorModel = await _professorRepository.UpdateAsync(id, dto);

            if (professorModel == null)
            {
                return NotFound();
            }

            return Ok(professorModel.ToProfessorDto());
        }

        
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var professorModel = await _professorRepository.DeleteAsync(id);

            if (professorModel == null)
            {
                return NotFound();
            }

            return Ok(professorModel.ToProfessorDto());
        }

        
        [HttpPut]
        [Route("redefinir-senha/{id}")]
        public async Task<IActionResult> RedefinirSenha([FromRoute] int id, [FromBody] string senha)
        {
            var professorModel = await _professorRepository.RedefinirSenhaAsync(id, senha);

            if (professorModel == null)
            {
                return NotFound();
            }

            return Ok(professorModel.ToProfessorDto());
        }
    }
}
