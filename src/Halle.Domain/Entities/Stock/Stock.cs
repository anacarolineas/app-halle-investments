namespace Halle.Domain.Entities.Stock
{
    public class Stock
    {
        public string Ticker { get; set; } = null!;
        public int Qtd { get; set; }
        public double Goal { get; set; }
    }
}
