namespace MoedaEstudantil.Entities
{
    public class Empresa : Pessoa
    {
        public List<Vantagem> VantagensOferecidas { get; set; }

        public Empresa()
        {
            VantagensOferecidas = new List<Vantagem>();
            Id = Guid.NewGuid();
        }
    }

}
