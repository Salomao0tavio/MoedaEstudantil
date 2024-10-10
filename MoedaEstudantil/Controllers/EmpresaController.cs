using Microsoft.AspNetCore.Mvc;
using MoedaEstudantil.Data;
using MoedaEstudantil.Entities;

namespace MoedaEstudantil.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly MeritSystemContext _context;

        public EmpresaController(MeritSystemContext context)
        {
            _context = context;
        }

        // CREATE - Cadastrar uma nova empresa parceira
        [HttpPost("cadastro")]
        public IActionResult CadastrarEmpresa([FromBody] Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return Ok("Empresa cadastrada com sucesso.");
        }

        // READ - Obter uma empresa parceira por ID
        [HttpGet("{id}")]
        public IActionResult ObterEmpresa(int id)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa == null) return NotFound("Empresa não encontrada.");
            return Ok(empresa);
        }

        // UPDATE - Atualizar dados de uma empresa parceira
        [HttpPut("{id}")]
        public IActionResult AtualizarEmpresa(int id, [FromBody] Empresa empresaAtualizada)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa == null) return NotFound("Empresa não encontrada.");

            empresa.Nome = empresaAtualizada.Nome;
            empresa.CPF = empresaAtualizada.CPF;
            empresa.Email = empresaAtualizada.Email;
            empresa.Senha = empresaAtualizada.Senha;

            _context.SaveChanges();
            return Ok("Empresa atualizada com sucesso.");
        }

        // DELETE - Deletar uma empresa parceira por ID
        [HttpDelete("{id}")]
        public IActionResult DeletarEmpresa(int id)
        {
            var empresa = _context.Empresas.Find(id);
            if (empresa == null) return NotFound("Empresa não encontrada.");

            _context.Empresas.Remove(empresa);
            _context.SaveChanges();
            return Ok("Empresa deletada com sucesso.");
        }

        // LIST - Obter todas as empresas parceiras
        [HttpGet("todas")]
        public IActionResult ObterTodasEmpresas()
        {
            var empresas = _context.Empresas.ToList();
            return Ok(empresas);
        }
    }

}
