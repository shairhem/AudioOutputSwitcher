namespace AudioOutputSwitcher.Strategies
{
    using System;
    using System.Threading.Tasks;

    public class ShowHelpStrategy : IStrategy
    {
        public async Task Handle(string[] args)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("[/h]            Show available commands");
                Console.WriteLine("[/l]            List active audio outputs");
                Console.WriteLine("[/d]device_id Set default audio output");
                Console.WriteLine("[/r]            Rotate default audio output");
            });
        }
    }
}
