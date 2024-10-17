using Microsoft.EntityFrameworkCore;
using MoedaEstudantil.Data;
using MoedaEstudantil.Entities;

namespace MoedaEstudantil.Services
{
    public class VantagemService
    {
        private readonly MeritSystemContext _context;

        public VantagemService(MeritSystemContext context)
        {
            _context = context;
        }

        public bool CadastrarVantagem(Vantagem vantagem)
        {
            _context.Vantagens.Add(vantagem);
            _context.SaveChanges();
            return true;
        }

        public Vantagem GetVantagemById(int id)
        {
            return _context.Vantagens
                .Include(v => v.EmpresaId)
                .FirstOrDefault(v => v.Id == id);
        }

        public bool AtualizarVantagem(Vantagem atualizado)
        {
            var vantagem = _context.Vantagens.Find(atualizado.Id);
            if (vantagem == null)
                return false;

            // Atualizar propriedades
            vantagem.Descricao = atualizado.Descricao;
            vantagem.Custo = atualizado.Custo;

            _context.SaveChanges();
            return true;
        }

        public bool DeletarVantagem(int id)
        {
            var vantagem = _context.Vantagens.Find(id);
            if (vantagem == null)
                return false;

            _context.Vantagens.Remove(vantagem);
            _context.SaveChanges();
            return true;
        }

        public List<Vantagem> ListarVantagens()
        {
            return _context.Vantagens.Include(v => v.EmpresaId).ToList();
        }
    }
}
