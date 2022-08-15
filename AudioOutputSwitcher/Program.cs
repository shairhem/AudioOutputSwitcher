namespace AudioOutputSwitcher
{
    using AudioOutputSwitcher.Strategies;
    using AudioSwitcher.AudioApi.CoreAudio;

    public class Program
    {
        static void Main(string[] args)
        {
            var arg = args.Length > 0 ? args[0] : string.Empty;
            var controller = new CoreAudioController();
            var strategyFactory = new StrategyFactory(controller);
            var strategy = strategyFactory.GetStrategy(arg);
            strategy.Handle(args).Wait();
        }
    }
}
