namespace ApiSqlAsp.Models
{
    public class EstadoDeVenda
    {
        public int Id { get; set; }

        public bool Vendido { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
