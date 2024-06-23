namespace Halle.Domain.Entities.Stock;

public class StockRebalancing
{
    public string Ticker { get; init; } = null!;
    public int Qtd { get; init; }
    public decimal CurrentQuote { get; init; }
    public decimal TotalPortfolioValue { get; init; }

    private decimal _currentValue;
    public decimal CurrentValue
    {
        get => Math.Round(_currentValue, 2);
        init => _currentValue = value;
    }

    private decimal _currentPercentage;
    public decimal CurrentPercentage
    {
        get => Math.Round(_currentPercentage, 2);
        init => _currentPercentage = value;
    }

    private decimal _goal;
    public decimal Goal
    {
        get => Math.Round(_goal, 2);
        init => _goal = value;
    }

    private decimal _goalDifference;
    public decimal GoalDifference
    {
        get => Math.Round(_goalDifference, 2);
        init => _goalDifference = value;
    }
}