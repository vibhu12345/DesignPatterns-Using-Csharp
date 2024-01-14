public class StrategyPattern<T>
{
    private Func<T,T> strategy;
    private readonly T input;

    public StrategyPattern(Func<T, T> strategy, T input)
    {
        this.strategy = strategy;
        this.input = input;
    }

    internal void ChangeStrategy(Func<T, T> reverseStringStrategy2)
    {
        strategy = reverseStringStrategy2;
    }

    internal T ExecuteStrategy()
    {
        return strategy(input);
    }
}