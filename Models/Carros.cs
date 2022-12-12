namespace ApiSqlAsp.Models
{
    public class Carros
    {
        public int Id { get; set; }

        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }

        public double Valor { get; set; }

        public int EstadoDeVendaId { get; set; }
        public EstadoDeVenda EstadoDeVenda { get; set; }
    }
}
