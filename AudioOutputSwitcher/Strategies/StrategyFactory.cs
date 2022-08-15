namespace AudioOutputSwitcher.Strategies
{
    using System;
    using System.Collections.Generic;
    using AudioSwitcher.AudioApi;

    public class StrategyFactory : IStrategyFactory
    {
        public readonly Dictionary<string, Func<IStrategy>> strategyMap;

        public StrategyFactory(IAudioController controller)
        {
            this.strategyMap = new Dictionary<string, Func<IStrategy>>();
            this.strategyMap.Add("/h", () => new ShowHelpStrategy());
            this.strategyMap.Add("/l", () => new ListDevicesStrategy(controller));
            this.strategyMap.Add("/d", () => new SetDeviceStrategy(controller));
            this.strategyMap.Add("/r", () => new RotateDeviceStrategy(controller));
        }

        public IStrategy GetStrategy(string arg)
        {
            IStrategy strategy;
            arg = arg?.ToLower();
            if (string.IsNullOrWhiteSpace(arg))
            {
                strategy = new ShowHelpStrategy();
            }
            else if (this.strategyMap.ContainsKey(arg))
            {
                strategy = this.strategyMap[arg]();
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }

            return strategy;
        }
    }
}
