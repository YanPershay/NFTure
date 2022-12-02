namespace NFTure.Core.Interfaces
{
    public interface IAppLogger
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
