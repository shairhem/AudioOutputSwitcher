namespace AudioOutputSwitcher.Strategies
{
    public interface IStrategyFactory
    {
        IStrategy GetStrategy(string arg);
    }
}
