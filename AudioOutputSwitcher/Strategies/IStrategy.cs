namespace AudioOutputSwitcher.Strategies
{
    using System.Threading.Tasks;

    public interface IStrategy
    {
        Task Handle(string[] args);
    }
}
