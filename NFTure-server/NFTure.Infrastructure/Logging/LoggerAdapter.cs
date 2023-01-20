using Microsoft.Extensions.Logging;
using NFTure.Core.Interfaces;

namespace NFTure.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogError(Type type, string message, params object[] args)
        {
            _logger.LogError($"{type.Name}: {message}");
        }

        public void LogInformation(Type type, string message, params object[] args)
        {
            _logger.LogInformation($"{type.Name}: {message}");
        }

        public void LogWarning(Type type, string message, params object[] args)
        {
            _logger.LogWarning($"{type.Name}: {message}");
        }
    }
}
