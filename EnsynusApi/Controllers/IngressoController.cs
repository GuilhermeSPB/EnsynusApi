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
        public async Task<IActionResult> GetAllAlunosAsync([FromRoute] int id)
        {
            var ingresso = await _ingressoRepository.GetAllAlunosAsync(id);

            if (ingresso == null)
            {
                return NotFound();
            }
            var result = ingresso.Select(i => i.ToIngressoVwAlunoAprovado());
            return Ok(result);
        }







        //[HttpPut]
        //[Route("edit/{id}")]
        //public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfessorDto updateDto)
        //{
        //    var professorModel = await _professorRepository.UpdateAsync(id, updateDto);

        //    if (professorModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(professorModel.ToProfessorDto);
        //}





        //[HttpPut]
        //[Route("redefinir-senha/{id}")]
        //public async Task<IActionResult> RedefinirSenha([FromRoute] int id, [FromBody] string senha)
        //{
        //    var professorModel = await _professorRepository.RedefinirSenhaAsync(id, senha);

        //    if (professorModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(professorModel.ToProfessorDto());
        //}
    }
}
