namespace MoedaEstudantil.Entities
{
    public class Vantagem
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public string Foto { get; set; }
    }

}
