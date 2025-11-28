using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EnsynusApi.Models;
using EnsynusApi.Repository.Professor;
using EnsynusApi.Dtos.Ingresso;
using EnsynusApi.Repository.Ingresso;

namespace EnsynusApi.Controllers
{
    [Route("ensynus/api/ingresso")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        private readonly IIngressoRepository _ingressoRepository;

        public IngressoController(IIngressoRepository ingressoRepository)
        {
            _ingressoRepository = ingressoRepository;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateIngressoDto createDto)
        {
            var ingressoModel = createDto.ToIngressoToCreateDto();
            await _ingressoRepository.CreateAsync(ingressoModel);

            return Ok(ingressoModel);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var ingressoModel = await _ingressoRepository.DeleteAsync(id);

            if (ingressoModel == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        [Route("aluno/aprovada/{id}")]
        public async Task<IActionResult> GetAllAlunosAprovadoAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllAlunosAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "APROVADA").Select(i => i.ToIngressoVwAlunoAprovado());
            return Ok(result);
        }

        [HttpGet]
        [Route("aluno/saiu/{id}")]
        public async Task<IActionResult> GetAllAlunosSaiuAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllAlunosAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "SAIU").Select(i => i.ToIngressoVwAlunoAprovado());
            return Ok(result);
        }

        [HttpGet]
        [Route("aluno/pendente/{id}")]
        public async Task<IActionResult> GetAllAlunosPendenteAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllAlunosAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "PENDENTE").Select(i => i.ToIngressoVwAlunoAprovado());
            return Ok(result);
        }

        [HttpGet]
        [Route("aluno/negada/{id}")]
        public async Task<IActionResult> GetAllAlunosNegadaAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllAlunosAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "NEGADA").Select(i => i.ToIngressoVwAlunoAprovado());
            return Ok(result);
        }

        [HttpGet]
        [Route("turma/aprovado/{id}")]
        public async Task<IActionResult> GetAllTurmasAprovadaAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllTurmasAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "APROVADA").Select(i => i.ToIngressoVwProfessorAprovadoDto());
            return Ok(result);
        }

        [HttpGet]
        [Route("turma/Pendente/{id}")]
        public async Task<IActionResult> GetAllTurmasPendenteAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllTurmasAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Where(i => i.Solicitacao == "PENDENTE").Select(i => i.ToIngressoVwProfessorAprovadoDto());
            return Ok(result);
        }   
    }
}
