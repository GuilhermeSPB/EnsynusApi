using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Models;
using EnsynusApi.Repository.Turma;
using EnsynusApi.Dtos.Turma;


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
            var dto = turmas.Select(t => t.ToTurmaDtoView());
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

            return Ok(turma.ToTurmaDtoView());
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateTurmaDto createDto)
        {
            var turmaDto = createDto.ToTurmaFromCreateDto();
            var turmaCriada = await _turmaRepository.CreateAsync(turmaDto);
            if(turmaCriada == null)
            {
                return BadRequest("Professor não encontrado");
            }
            return Ok(turmaCriada);
        }


        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTurmaDto updateDto)
        {
            var turmaModel = await _turmaRepository.UpdateAsync(id, updateDto);

            if (turmaModel == null)
            {
                 return NotFound();
            }

            return Ok(turmaModel.ToTurmaDto());
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var turmaModel = await _turmaRepository.DeleteAsync(id);

            if (turmaModel == null)
            {
                return NotFound();
            }

            return Ok(turmaModel.ToTurmaDto());
        }
    }
}
