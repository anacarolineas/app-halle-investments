namespace Halle.Domain.Entities.Stock;

public class StockRebalancing
{
    public string Ticker { get; init; } = null!;
    public int Qtd { get; init; }
    public double CurrentQuote { get; init; }

    private double _currentValue;
    public double CurrentValue
    {
        get => Math.Round(_currentValue, 2);
        init => _currentValue = value;
    }

    private double _currentPercentage;
    public double CurrentPercentage
    {
        get => Math.Round(_currentPercentage, 2);
        init => _currentPercentage = value;
    }

    private double _goal;
    public double Goal
    {
        get => Math.Round(_goal, 2);
        init => _goal = value;
    }

    private double _goalDifference;
    public double GoalDifference
    {
        get => Math.Round(_goalDifference, 2);
        init => _goalDifference = value;
    }
}