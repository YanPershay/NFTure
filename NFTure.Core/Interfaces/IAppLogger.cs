namespace NFTure.Core.Interfaces
{
    public interface IAppLogger<T>
    {
        void LogInformation(Type type, string message, params object[] args);
        void LogWarning(Type type, string message, params object[] args);
        void LogError(Type type, string message, params object[] args);
    }
}
