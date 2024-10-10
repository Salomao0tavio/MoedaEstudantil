using Microsoft.AspNetCore.Mvc;
using MoedaEstudantil.Data;
using MoedaEstudantil.Entities;

namespace MoedaEstudantil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly MeritSystemContext _context;

        public AlunoController(MeritSystemContext context)
        {
            _context = context;
        }

        // CREATE - Cadastrar um novo aluno
        [HttpPost("cadastro")]
        public IActionResult CadastrarAluno([FromBody] Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Ok("Aluno cadastrado com sucesso.");
        }

        // READ - Obter um aluno por ID
        [HttpGet("{id}")]
        public IActionResult ObterAluno(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound("Aluno não encontrado.");
            return Ok(aluno);
        }

        // UPDATE - Atualizar dados de um aluno
        [HttpPut("{id}")]
        public IActionResult AtualizarAluno(int id, [FromBody] Aluno alunoAtualizado)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound("Aluno não encontrado.");

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Email = alunoAtualizado.Email;
            aluno.CPF = alunoAtualizado.CPF;
            aluno.RG = alunoAtualizado.RG;
            aluno.Endereco = alunoAtualizado.Endereco;
            aluno.InstituicaoEnsino = alunoAtualizado.InstituicaoEnsino;
            aluno.Curso = alunoAtualizado.Curso;

            _context.SaveChanges();
            return Ok("Aluno atualizado com sucesso.");
        }

        // DELETE - Deletar um aluno por ID
        [HttpDelete("{id}")]
        public IActionResult DeletarAluno(int id)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null) return NotFound("Aluno não encontrado.");

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Ok("Aluno deletado com sucesso.");
        }

        // LIST - Obter todos os alunos
        [HttpGet("todos")]
        public IActionResult ObterTodosAlunos()
        {
            var alunos = _context.Alunos.ToList();
            return Ok(alunos);
        }
    }

}
