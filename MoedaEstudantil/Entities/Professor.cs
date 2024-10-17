using MoedaEstudantil.Enums;

namespace MoedaEstudantil.Entities
{
    public class Professor : Pessoa
    {
        public string Departamento { get; set; }
        public string Instituicao { get; set; }
        public decimal SaldoMoedas { get; set; }

        public List<Transacao> Transacoes { get; set; }

        public Professor()
        {
            Transacoes = new List<Transacao>();
            SaldoMoedas = 1000; // Inicia com 1000 moedas por semestre
        }
    }

}
